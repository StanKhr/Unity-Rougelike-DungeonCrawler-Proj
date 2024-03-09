using System;
using System.Collections.Generic;
using Miscellaneous;
using Unity.AI.Navigation;
using UnityEngine;
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
        private const float RotateRoomChance = 0.5f;

        #endregion
        
        #region Events
        
        public event Action OnGenerationStarted;
        public event Action OnGenerationEnded;

        #endregion

        #region Editor Fields

        [SerializeField] private int _randomSeed = 0;
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
            Randomizer.SetSeed(_randomSeed);
            
            OnGenerationStarted?.Invoke();

            GenerateLayout();
            SpawnTiles();
            FillRooms();
            BakeNavigation();
            SpawnEnemies();
            
            OnGenerationEnded?.Invoke();
        }

        #endregion

        #region Methods

        public void GenerateLayout()
        {
            _corridorTiles.Clear();
            _rooms.Clear();
            
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
                if (_rooms.Count + 1 < expectedRoomCount)
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
                    _corridorTiles.Add(roomSpawnPosition);
                    
                    if (_dungeonGrid.GetCellByAxis(roomSpawnPosition) == CellType.Floor)
                    {
                        continue;
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
                        PlacePrefab(cellPosition, LevelTiles.GetFloor());
                        break;
                    case CellType.Wall:
                        var wallInstance = PlacePrefab(cellPosition, LevelTiles.GetWall());
                        TryUpdateWallTile(cellPosition, wallInstance);
                        break;
                    case CellType.Door:
                        break;
                }
            }
        }

        private void FillRooms()
        {
            var fillingsContainer = new GameObject(RoomFillingsContainerName);

            var bossRoomFillingPrefab = RoomFillingsSettings.GetBossRoomFilling();
            var bossRoom = _rooms[^1];
            
            var filling = Instantiate(bossRoomFillingPrefab, bossRoom.GetWorldPosition(_gridCellScale), Quaternion.identity,
                fillingsContainer.transform);
            if (bossRoom.Rotated)
            {
                filling.Rotate();
            }
            else
            {
                filling.TryMirror();
            }
            
            for (int i = 1; i < _rooms.Count - 1; i++)
            {
                var roomSize = _rooms[i].GetSize();
                if (!RoomFillingsSettings.TryGetFilling(roomSize, out var fillingPrefab))
                {
                    continue;
                }
                
                Instantiate(fillingPrefab, _rooms[i].GetWorldPosition(_gridCellScale), Quaternion.identity,
                    fillingsContainer.transform);
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
            for (int i = 0; i < 100; i++)
            {
                var enemy = SpawnableEnemies.GetEnemy(EnemyType.Basic);
                LogWriter.DevelopmentLog($"ENEMY TO SPAWN: {enemy.name}");
            }
        }

        private GameObject PlacePrefab(Vector2Int cellPosition, GameObject prefab)
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