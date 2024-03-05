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

        [SerializeField, Min(0)] private int _minRoomDistance = 1; 
        [SerializeField, Min(0)] private int _maxRoomDistance = 2; 
        [SerializeField] private RoomData _spawnRoomData;

        [Header("Debug")]
        [SerializeField] private GameObject _floorPrefabDebug;
        [SerializeField] private Material _materialRed;
        [SerializeField] private Material _materialBlue;

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

                var spawnPosition = new Vector3(cellPosition.x, 0f, cellPosition.y);
                var prefab = Instantiate(_floorPrefabDebug, spawnPosition, Quaternion.identity);
                prefab.SetActive(true);
                
                prefab.name = $"Cell_{Enum.GetName(typeof(CellType), cells[cellPosition])}_{cellPosition.x.ToString()}_{cellPosition.y.ToString()}";

                var meshRenderer = prefab.GetComponentInChildren<MeshRenderer>();
                meshRenderer.material = cells[cellPosition] == CellType.Floor ? _materialBlue : _materialRed;
            }
        }

        #endregion
    }
}