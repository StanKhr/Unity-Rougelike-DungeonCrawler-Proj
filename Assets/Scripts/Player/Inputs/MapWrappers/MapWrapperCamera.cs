using System;
using Player.Inputs.Interfaces;
using Scripts.Player.Inputs;

namespace Player.Inputs.MapWrappers
{
    public class MapWrapperCamera : MapWrapper, IMapWrapperCamera
    {
        #region Constructors

        public MapWrapperCamera(GameControlsAsset gameControlsAsset) : base(gameControlsAsset)
        {
            
        }

        #endregion

        #region Fields

        

        #endregion
        
        #region Methods

        public void EnableMap(bool enable)
        {
            if (!enable)
            {
                GameControlsAsset.CameraMap.Disable();
                return;
            }
            
            GameControlsAsset.CameraMap.Enable();
        }

        #endregion
    }
}