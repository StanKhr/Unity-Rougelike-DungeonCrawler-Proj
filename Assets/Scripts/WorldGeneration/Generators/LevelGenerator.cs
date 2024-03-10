using System;
using System.Collections.Generic;
using Miscellaneous;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using WorldGeneration.Data;
using WorldGeneration.Enums;
using WorldGeneration.Interfaces;
using WorldGeneration.Settings;
using WorldGeneration.Utility;

namespace WorldGeneration.Generators
{
    public class LevelGenerator : MonoBehaviour, ILevelGenerator
    {
        #region Constants

        private const string RoomFillingsContainerName = "RoomFillings";
        private const string EnemiesContainerName = "Enemies";
        private const float RotateRoomChance = 0.5f;
        private const int MinimumEnemiesPerRoom = 1;
        private const float MaxEnemySpawnDistanceOffset = 10f;

        #endregion

        #region Events

        public event Action OnGenerationStarted;
        public event Action OnGenerationEnded;

        #endregion

        #region Editor Fields

        [SerializeField, Min(0)] private int _gridCellScale = 1;

        [SerializeField] private LevelLayoutSettings _levelLayoutSettings;
        [SerializeField] private LevelTiles _levelTiles;
        [SerializeField] private RoomFillingsSettings _roomFillingsSettings;
        [SerializeField] private NavMeshSurface _navMeshSurface;
        [SerializeField] private SpawnableEnemies _spawnableEnemies;

        #endregion

        #region Fields

        private readonly DungeonGrid _dungeonGrid = new();
        private readonly HashSet<Vector2Int> _corridorTiles = new();
        private readonly List<RoomData> _rooms = new();
        private readonly Dictionary<WalkDirectionType, Vector2Int> _sortedWalkDirections = new()
        {
            {WalkDirectionType.Right, new Vector2Int(1, 0)},
            {WalkDirectionType.Top, new Vector2Int(0, 1)},
            {WalkDirectionType.Left, new Vector2Int(-1, 0)},
            {WalkDirectionType.Bot, new Vector2Int(0, -1)},
        };
        private readonly List<Vector2Int> _directionsTempList = new();

        #endregion

        #region Properties

        private ILevelLayoutSettings LevelLayoutSettings => _levelLayoutSettings;
        private ILevelTiles LevelTiles => _levelTiles;
        private IRoomFillingsSettings RoomFillingsSettings => _roomFillingsSettings;
        private ISpawnableEnemies SpawnableEnemies => _spawnableEnemies;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            (this as ILevelGenerator).CallGeneratorLoadedEvent(this);
            
            var randomSeed = Guid.NewGuid().GetHashCode();
            Generate(randomSeed);
        }

        #endregion

        #region Methods

        public void Generate(int seed)
        {
            Clear();
            
            Randomizer.SetSeed(seed);

            OnGenerationStarted?.Invoke();

            GenerateLayout();
            SpawnTiles();
            FillRooms();
            BakeNavigation();
            SpawnEnemies();

            OnGenerationEnded?.Invoke();
        }

        public void Clear()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                Destroy(child.gameObject);
            }
            
            _corridorTiles.Clear();
            _rooms.Clear();
            _dungeonGrid.Clear();
        }

        private void GenerateLayout()
        {
            var roomSpawnPosition = new Vector2Int(0, 0);

            var startRoom = LevelLayoutSettings.GetStartRoom();
            _dungeonGrid.AddRoom(startRoom);
            _rooms.Add(startRoom);

            var expectedRoomCount = LevelLayoutSettings.GetExpectedRoomsAmount();
            while (_rooms.Count < expectedRoomCount)
            {
                var direction = GetRandomDirection();
                var sideDirection = new Vector2Int(direction.y, direction.x);

                var corridorSteps = LevelLayoutSettings.GetCorridorSteps();

                RoomData nextRoom;
                var bossRoom = _rooms.Count + 1 >= expectedRoomCount;
                if (!bossRoom)
                {
                    nextRoom = LevelLayoutSettings.GetRandomRoom();
                }
                else
                {
                    nextRoom = LevelLayoutSettings.GetBossRoom();
                }

                if (Randomizer.ComparePercent(RotateRoomChance))
                {
                    nextRoom.RotateBy90Degrees();
                }

                var extraSteps = 0;
                if (direction.x != 0)
                {
                    extraSteps = (nextRoom.SizeX + 1) / 2;
                }
                else
                {
                    extraSteps = (nextRoom.SizeY + 1) / 2;
                }

                corridorSteps += extraSteps;
                while (corridorSteps > 0)
                {
                    roomSpawnPosition += direction;

                    if (_dungeonGrid.GetCellByAxis(roomSpawnPosition) == CellType.Floor)
                    {
                        continue;
                    }

                    if (!bossRoom)
                    {
                        _corridorTiles.Add(roomSpawnPosition);
                    }

                    corridorSteps--;

                    _dungeonGrid.SetCell(roomSpawnPosition, CellType.Floor);
                    _dungeonGrid.SetCell(roomSpawnPosition + sideDirection, CellType.Wall);
                    _dungeonGrid.SetCell(roomSpawnPosition - sideDirection, CellType.Wall);
                }

                nextRoom.GridCenterPosition = roomSpawnPosition;

                _dungeonGrid.AddRoom(nextRoom);
                _rooms.Add(nextRoom);
            }
        }

        private Vector2Int GetRandomDirection()
        {
            if (_directionsTempList.Count == 0)
            {
                _directionsTempList.AddRange(_sortedWalkDirections.Values);
            }

            var directionIndex = Randomizer.RangeInt(0, _directionsTempList.Count);
            var direction = _directionsTempList[directionIndex];
            _directionsTempList.RemoveAt(directionIndex);

            return direction;
        }

        private void SpawnTiles()
        {
            var cells = _dungeonGrid.Cells;
            foreach (var cellPosition in cells.Keys)
            {
                if (cells[cellPosition] == CellType.Empty)
                {
                    continue;
                }

                switch (cells[cellPosition])
                {
                    case CellType.Empty:
                        break;
                    case CellType.Floor:
                        PlaceTilePrefab(cellPosition, LevelTiles.GetFloor());
                        break;
                    case CellType.Wall:
                        var wallInstance = PlaceTilePrefab(cellPosition, LevelTiles.GetWall());
                        TryUpdateWallTile(cellPosition, wallInstance);
                        break;
                    case CellType.Door:
                        break;
                }
            }
        }

        private void FillRooms()
        {
            var fillingsContainer = new GameObject(RoomFillingsContainerName)
            {
                transform =
                {
                    parent = transform
                }
            };
            
            var roomBoundsList = new List<Bounds>();
            var startRoom = _rooms[0];
            
            roomBoundsList.Add(startRoom.GetBounds(_gridCellScale));

            var bossRoomFillingPrefab = RoomFillingsSettings.GetBossRoomFilling();
            var bossRoom = _rooms[^1];

            var roomFilling = Instantiate(bossRoomFillingPrefab, bossRoom.GetWorldCenterPosition(_gridCellScale),
                Quaternion.identity,
                fillingsContainer.transform);
            if (bossRoom.Rotated)
            {
                roomFilling.Rotate();
            }
            else
            {
                roomFilling.TryMirror();
            }

            roomBoundsList.Add(bossRoom.GetBounds(_gridCellScale));

            for (int i = 1; i < _rooms.Count - 1; i++)
            {
                // getting room's filling prefab
                var roomSize = _rooms[i].GetGridSize();
                if (!RoomFillingsSettings.TryGetFilling(roomSize, out var fillingPrefab))
                {
                    continue;
                }
                
                // checking intersections
                var roomBounds = _rooms[i].GetBounds(_gridCellScale);
                var skipRoom = false;
                for (int j = 0; j < roomBoundsList.Count; j++)
                {
                    if (roomBounds.Intersects(roomBoundsList[j]))
                    {
                        skipRoom = true;
                        break;
                    }
                }

                if (skipRoom)
                {
                    continue;
                }
                
                roomBoundsList.Add(roomBounds);

                // instantiating room filling
                roomFilling = Instantiate(fillingPrefab, _rooms[i].GetWorldCenterPosition(_gridCellScale),
                    Quaternion.identity, fillingsContainer.transform);
                if (_rooms[i].Rotated)
                {
                    roomFilling.Rotate();
                }
                else
                {
                    roomFilling.TryMirror();
                }
            }

            foreach (var tile in _corridorTiles)
            {
                var trashPrefab = RoomFillingsSettings.GetCorridorTrash();
                if (!trashPrefab)
                {
                    continue;
                }

                var trashWorldPosition = new Vector3(tile.x, 0f, tile.y) * _gridCellScale;
                Instantiate(trashPrefab, trashWorldPosition, Quaternion.identity, fillingsContainer.transform);
            }
        }

        private void BakeNavigation()
        {
            _navMeshSurface.BuildNavMesh();
        }

        private void SpawnEnemies()
        {
            var enemyParent = new GameObject(EnemiesContainerName)
            {
                transform =
                {
                    parent = transform
                }
            };

            for (var i = 1; i < _rooms.Count; i++)
            {
                var roomData = _rooms[i];
                int enemiesAmount = roomData.MaxEnemies <= MinimumEnemiesPerRoom
                    ? MinimumEnemiesPerRoom
                    : Randomizer.RangeInt(MinimumEnemiesPerRoom, roomData.MaxEnemies);

                for (int j = 0; j < enemiesAmount; j++)
                {
                    var spawnPosition = roomData.GetRandomInsidePosition(_gridCellScale);

                    if (!NavMesh.SamplePosition(spawnPosition, out var hit, MaxEnemySpawnDistanceOffset,
                            NavMesh.AllAreas))
                    {
                        continue;
                    }

                    var enemyPrefab = SpawnableEnemies.GetEnemy(EnemyType.Basic);
                    Instantiate(enemyPrefab, hit.position, Quaternion.identity, enemyParent.transform);
                }
            }
        }

        private GameObject PlaceTilePrefab(Vector2Int cellPosition, GameObject prefab)
        {
            var spawnPosition = ConvertGridPositionToWorld(cellPosition);
            var instance = Instantiate(prefab, spawnPosition, Quaternion.identity, transform);
            instance.SetActive(true);
            return instance;
        }

        private void TryUpdateWallTile(Vector2Int cellPosition, GameObject instance)
        {
            if (!instance.TryGetComponent<IWallTile>(out var wallTile))
            {
                return;
            }

            foreach (var key in _sortedWalkDirections.Keys)
            {
                var checkPosition = cellPosition + _sortedWalkDirections[key];
                wallTile.SetTile(key, _dungeonGrid.GetCellByAxis(checkPosition) == CellType.Floor);
            }
        }

        private Vector3 ConvertGridPositionToWorld(Vector2Int gridPosition)
        {
            return new Vector3(gridPosition.x * _gridCellScale, 0f, gridPosition.y * _gridCellScale);
        }

        #endregion
    }
}