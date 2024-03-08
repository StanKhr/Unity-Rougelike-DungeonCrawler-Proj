using System;
using System.Collections.Generic;
using UnityEngine;
using WorldGeneration.Data;
using WorldGeneration.Enums;
using WorldGeneration.Interfaces;
using WorldGeneration.Settings;
using WorldGeneration.Utility;
using Random = UnityEngine.Random;

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
        [SerializeField] private RoomData _spawnRoomData;
        [SerializeField] private RoomData[] _roomsToSpawn;
        [SerializeField] private int _corridorMinSteps = 1;
        [SerializeField] private int _corridorMaxSteps = 2;
        [SerializeField, Min(2)] private int _requiredRoomsAmount = 5;
        [SerializeField] private int _extraRoomsMaxAmount = 5;
        [SerializeField] private LevelTiles _levelTiles;
        [SerializeField] private RoomFilling[] _roomFillings;
        
        #endregion

        #region Fields

        private readonly DungeonGrid _dungeonGrid = new();
        private readonly List<RoomData> _rooms = new();
        private readonly Dictionary<WalkDirectionType, Vector2Int> _sortedWalkDirections = new()
        {
            {WalkDirectionType.Right, new Vector2Int(1, 0)},
            {WalkDirectionType.Top, new Vector2Int(0, 1)},
            {WalkDirectionType.Left, new Vector2Int(-1, 0)},
            {WalkDirectionType.Bot, new Vector2Int(0, -1)},
        };
        private readonly List<Vector2Int> _directionsTempList = new();
        private readonly Dictionary<Vector2Int, List<RoomFilling>> _sortedRoomFillings = new();

        #endregion

        #region Properties

        private ILevelTiles LevelTiles => _levelTiles;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Random.InitState(_randomSeed);
            
            OnGenerationStarted?.Invoke();

            SortRoomFillings();
            StartGeneration();
            SpawnTiles();
            FillRooms();
            BakeNavigation();
            
            OnGenerationEnded?.Invoke();
        }

        #endregion

        #region Methods

        private void SortRoomFillings()
        {
            _sortedRoomFillings.Clear();

            for (int i = 0; i < _roomFillings.Length; i++)
            {
                var roomSize = _roomFillings[i].GetRoomSize();
                if (!_sortedRoomFillings.TryGetValue(roomSize, out var fillingsList))
                {
                    fillingsList = new List<RoomFilling>();
                    _sortedRoomFillings.Add(roomSize, fillingsList);
                }

                if (fillingsList.Contains(_roomFillings[i]))
                {
                    continue;
                }
                
                fillingsList.Add(_roomFillings[i]);
            }
        }
        public void StartGeneration()
        {
            _rooms.Clear();
            
            var roomSpawnPosition = new Vector2Int(0, 0);
            
            _dungeonGrid.AddRoom(_spawnRoomData);
            _rooms.Add(_spawnRoomData);

            var expectedRoomCount = _requiredRoomsAmount + Random.Range(0, _extraRoomsMaxAmount);
            while (_rooms.Count < expectedRoomCount)
            {
                var direction = GetRandomDirection();
                var sideDirection = new Vector2Int(direction.y, direction.x);

                var corridorSteps = Random.Range(_corridorMinSteps, _corridorMaxSteps);
                var room = _roomsToSpawn[Random.Range(0, _roomsToSpawn.Length)];

                if (Random.Range(0f, 1f) <= RotateRoomChance)
                {
                    room.RotateBy90Degrees();
                }

                var extraSteps = 0;
                if (direction.x != 0)
                {
                    extraSteps = (room.SizeX + 1) / 2;
                }
                else
                {
                    extraSteps = (room.SizeY + 1) / 2;
                } 

                corridorSteps += extraSteps;
                while (corridorSteps > 0)
                {
                    roomSpawnPosition += direction;
                    
                    if (_dungeonGrid.GetCellByAxis(roomSpawnPosition) == CellType.Floor)
                    {
                        continue;
                    }
                    
                    corridorSteps--;
                    
                    _dungeonGrid.SetCell(roomSpawnPosition, CellType.Floor);
                    _dungeonGrid.SetCell(roomSpawnPosition + sideDirection, CellType.Wall);
                    _dungeonGrid.SetCell(roomSpawnPosition - sideDirection, CellType.Wall);
                }

                room.GridCenterPosition = roomSpawnPosition;
                
                _dungeonGrid.AddRoom(room);
                _rooms.Add(room);
            }
        }

        private Vector2Int GetRandomDirection()
        {
            if (_directionsTempList.Count == 0)
            {
                _directionsTempList.AddRange(_sortedWalkDirections.Values);
            }

            var directionIndex = Random.Range(0, _directionsTempList.Count);
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
            for (int i = 0; i < _rooms.Count; i++)
            {
                var size = _rooms[i].GetSize();
                if (!_sortedRoomFillings.TryGetValue(size, out var fillingsList))
                {
                    continue;
                }

                var randomIndex = Random.Range(0, fillingsList.Count);
                var fillingPrefab = fillingsList[randomIndex];
                Instantiate(fillingPrefab, _rooms[i].GetWorldPosition(_gridCellScale), Quaternion.identity);
            }
        }

        private void BakeNavigation()
        {
            
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