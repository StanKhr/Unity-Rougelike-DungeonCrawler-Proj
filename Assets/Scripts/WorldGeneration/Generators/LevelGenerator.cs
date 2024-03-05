using System;
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
        // [SerializeField, Min(0)] private int _levelBoundsX = 50;
        // [SerializeField, Min(0)] private int _levelBoundsY = 50;

        // [SerializeField, Min(0)] private int _minRoomDistance = 1; 
        // [SerializeField, Min(0)] private int _maxRoomDistance = 2;
        [SerializeField, Min(0)] private int _gridCellSize = 1;
        [SerializeField] private RoomData _spawnRoomData;

        [Header("Debug")]
        [SerializeField] private GameObject _floorPrefabDebug;
        [SerializeField] private GameObject _wallPrefabDebug;
        #endregion

        #region Fields

        private readonly DungeonGrid _dungeonGrid = new();

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
            // var levelMiddleX = _levelBoundsX % 2 == 0 ? _levelBoundsX / 2 : (_levelBoundsX + 1) / 2;
            // var levelMiddleY = _levelBoundsY % 2 == 0 ? _levelBoundsY / 2 : (_levelBoundsY + 1) / 2;
            // var startPoint = new Vector2Int
            // {
                // x = Random.Range(-levelMiddleX, levelMiddleX),
                // y = Random.Range(-levelMiddleY, levelMiddleY)
            // };

            var startPoint = new Vector2Int(0,0);
            
            _dungeonGrid.AddRoom(_spawnRoomData);
            // LogWriter.DevelopmentLog($"[LG] Start point: {startPoint.ToString()}");
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
                    case CellType.BossReservedPath:
                    case CellType.Floor:
                        PlaceFloor(cellPosition, _floorPrefabDebug);
                        break;
                    case CellType.Wall:
                        PlaceFloor(cellPosition, _wallPrefabDebug);
                        break;
                    case CellType.Door:
                        break;
                }
            }
        }

        private void PlaceFloor(Vector2Int cellPosition, GameObject prefab)
        {
            var spawnPosition = ConvertGridPositionToWorld(cellPosition);
            var instance = Instantiate(prefab, spawnPosition, Quaternion.identity, transform);
            instance.SetActive(true);

#if UNITY_EDITOR || DEVELOPMENT_BUILD
            instance.name = GetCellName(cellPosition, CellType.Floor);
#endif
                
            // var meshRenderer = prefab.GetComponentInChildren<MeshRenderer>();
            // meshRenderer.material = cells[cellPosition] == CellType.Floor ? _materialBlue : _materialRed;
        }

        private string GetCellName(Vector2Int cellPosition, CellType type)
        {
            return
                $"Cell_{Enum.GetName(typeof(CellType), type)}_{cellPosition.x.ToString()}_{cellPosition.y.ToString()}";
        }

        private Vector3 ConvertGridPositionToWorld(Vector2Int gridPosition)
        {
            return new Vector3(gridPosition.x * _gridCellSize, 0f, gridPosition.y * _gridCellSize);
        }

        #endregion
    }
}