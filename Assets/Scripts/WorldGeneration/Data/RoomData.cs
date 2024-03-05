using System;
using UnityEngine;

namespace WorldGeneration.Data
{
    [Serializable]
    public struct RoomData
    {
        #region Constants

        public RoomData(Vector2Int worldCenterPosition, int sizeX, int sizeY)
        {
            WorldCenterPosition = worldCenterPosition;
            SizeX = sizeX;
            SizeY = sizeY;
        }

        #endregion

        #region Editor Fields

        [field: SerializeField] public Vector2Int WorldCenterPosition { get; set; }
        [field: SerializeField] public int SizeX { get; set; }
        [field: SerializeField] public int SizeY { get; set; }

        #endregion

        #region Methods

        public void RotateBy90Degrees()
        {
            (SizeX, SizeY) = (SizeY, SizeX);
        }

        #endregion
    }
}