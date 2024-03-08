using System;
using UnityEngine;

namespace WorldGeneration.Data
{
    [Serializable]
    public struct RoomData
    {
        #region Constants

        public RoomData(Vector2Int gridCenterPosition, int sizeX, int sizeY)
        {
            GridCenterPosition = gridCenterPosition;
            SizeX = sizeX;
            SizeY = sizeY;
            Rotated = false;
        }

        #endregion

        #region Editor Fields

        public Vector2Int GridCenterPosition { get; set; }
        [field: SerializeField] public int SizeX { get; set; }
        [field: SerializeField] public int SizeY { get; set; }
        public bool Rotated { get; private set; }

        #endregion

        #region Methods

        public Vector3 GetWorldPosition(int gridCellScale)
        {
            return new Vector3(GridCenterPosition.x, 0f, GridCenterPosition.y) * gridCellScale;
        }
        
        public Vector2Int GetSize()
        {
            return new Vector2Int(SizeX, SizeY);
        }
        
        public void RotateBy90Degrees()
        {
            (SizeX, SizeY) = (SizeY, SizeX);
            Rotated = true;
        }

        #endregion
    }
}