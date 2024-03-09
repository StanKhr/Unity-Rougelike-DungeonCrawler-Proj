using UnityEngine;

namespace WorldGeneration.Interfaces
{
    public interface ILevelTiles
    {
        #region Properties

        

        #endregion

        #region Methods

        GameObject GetWall();
        GameObject GetFloor();

        #endregion
    }
}