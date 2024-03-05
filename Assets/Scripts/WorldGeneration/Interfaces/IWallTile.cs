using WorldGeneration.Enums;

namespace WorldGeneration.Interfaces
{
    public interface IWallTile
    {
        #region Methods

        void SetTile(WalkDirectionType directionType, bool state);

        #endregion
    }
}