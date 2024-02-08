using Scripts.Player.Inputs;

namespace Player.Inputs.MapWrappers
{
    public abstract class MapWrapper
    {
        #region Constructors

        protected MapWrapper(GameControlsAsset gameControlsAsset)
        {
            GameControlsAsset = gameControlsAsset;
        }

        #endregion

        #region Properties
        
        protected GameControlsAsset GameControlsAsset { get; }

        #endregion
    }
}