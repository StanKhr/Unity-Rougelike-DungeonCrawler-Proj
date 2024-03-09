using System;
using Miscellaneous;
using UnityEngine;

namespace WorldGeneration.Data
{
    [Serializable]
    public struct RoomData
    {
        #region Constants

        public RoomData(Vector2Int gridCenterPosition, int sizeX, int sizeY, int maxEnemies)
        {
            GridCenterPosition = gridCenterPosition;
            SizeX = sizeX;
            SizeY = sizeY;
            Rotated = false;
            MaxEnemies = maxEnemies;
        }

        #endregion

        #region Editor Fields

        public Vector2Int GridCenterPosition { get; set; }
        [field: SerializeField] public int SizeX { get; set; }
        [field: SerializeField] public int SizeY { get; set; }
        [field: SerializeField, Min(1)] public int MaxEnemies { get; set; }
        public bool Rotated { get; private set; }

        #endregion

        #region Methods

        public Vector3 GetWorldCenterPosition(int gridCellScale)
        {
            return new Vector3(GridCenterPosition.x, 0f, GridCenterPosition.y) * gridCellScale;
        }

        public Vector3 GetRandomInsidePosition(int gridCellScale)
        {
            var x = Randomizer.RangeInt(-SizeX, SizeX + 1);
            var y = Randomizer.RangeInt(-SizeY, SizeY + 1);

            var center = GetWorldCenterPosition(gridCellScale);

            if (!Rotated)
            {
                return center + new Vector3(x, 0f, y) * gridCellScale;
            }

            return center + new Vector3(y, 0f, x) * gridCellScale;
        }
        
        public Vector2Int GetGridSize()
        {
            if (!Rotated)
            {
                return new Vector2Int(SizeX, SizeY);
            }

            return new Vector2Int(SizeY, SizeX);
        }
        
        public void RotateBy90Degrees()
        {
            (SizeX, SizeY) = (SizeY, SizeX);
            Rotated = true;
        }

        public Bounds GetBounds(int gridCellScale)
        {
            var center = GetWorldCenterPosition(gridCellScale);
            var size = GetGridSize();
            return new Bounds(center, new Vector3(size.x, 0f, size.y) * gridCellScale);
        }

        #endregion
    }
}