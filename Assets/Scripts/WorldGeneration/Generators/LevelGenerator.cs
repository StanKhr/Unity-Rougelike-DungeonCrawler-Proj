using System;
using System.Collections.Generic;
using Miscellaneous;
using UnityEngine;
using WorldGeneration.Data;
using WorldGeneration.Enums;
using WorldGeneration.Interfaces;
using WorldGeneration.Utility;
using Random = UnityEngine.Random;

namespace WorldGeneration.Generators
{
    public class LevelGenerator : MonoBehaviour, ILevelGenerator
    {
        #region Constants

        private static readonly Vector3Int CorridorTileSize = new Vector3Int(3, 3);

        #endregion
        
        #region Events
        
        public event Action OnGenerationStarted;
        public event Action OnGenerationEnded;

        #endregion

        #region Editor Fields

        [SerializeField] private int _randomSeed = 0;
        [SerializeField, Min(0)] private int _gridCellSize = 1;
        [SerializeField] private RoomData _spawnRoomData;
        [SerializeField] private RoomData[] _roomsToSpawn;
        [SerializeField] private int _corridorMinSteps = 1;
        [SerializeField] private int _corridorMaxSteps = 2;
        [SerializeField, Min(2)] private int _requiredRoomsAmount = 5;
        [SerializeField] private int _extraRoomsMaxAmount = 5;

        [Header("Debug")]
        [SerializeField] private GameObject _floorPrefabDebug;
        [SerializeField] private GameObject _wallPrefabDebug;
        
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

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Random.InitState(_randomSeed);
            
            StartGeneration();
            SpawnDebugTiles();
        }

        #endregion

        #region Methods

        public void StartGeneration()
        {
            var roomSpawnPosition = new Vector2Int(0, 0);
            
            _dungeonGrid.AddRoom(_spawnRoomData);
            _rooms.Add(_spawnRoomData);

            var directionsCount = Enum.GetNames(typeof(WalkDirectionType)).Length;
            var expectedRoomCount = _requiredRoomsAmount + Random.Range(0, _extraRoomsMaxAmount);
            while (_rooms.Count < expectedRoomCount)
            {
                var prevPosition = roomSpawnPosition;
                var moveDirectionType = (WalkDirectionType) Random.Range(0, directionsCount);
                var direction = _sortedWalkDirections[moveDirectionType];
                var sideDirection = new Vector2Int(direction.y, direction.x);

                var corridorSteps = Random.Range(_corridorMinSteps, _corridorMaxSteps);
                var room = _roomsToSpawn[Random.Range(0, _roomsToSpawn.Length)];

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

                room.WorldCenterPosition = roomSpawnPosition;
                
                _dungeonGrid.AddRoom(room);
                _rooms.Add(room);
            }
        }
        
        private void SpawnDebugTiles()
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
                        PlacePrefab(cellPosition, _floorPrefabDebug);
                        break;
                    case CellType.Wall:
                        var wallInstance = PlacePrefab(cellPosition, _wallPrefabDebug);
                        TryUpdateWallTile(cellPosition, wallInstance);
                        break;
                    case CellType.Door:
                        break;
                }
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
            return new Vector3(gridPosition.x * _gridCellSize, 0f, gridPosition.y * _gridCellSize);
        }

        #endregion
    }
}