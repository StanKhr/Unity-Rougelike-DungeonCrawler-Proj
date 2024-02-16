using System;
using Player.Inputs.Interfaces;
using Scripts.Player.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Inputs.MapWrappers
{
    public class MapWrapperCamera : MapWrapper, IMapWrapperCamera, GameControlsAsset.ICameraMapActions
    {
        #region Constructors

        public MapWrapperCamera(GameControlsAsset gameControlsAsset) : base(gameControlsAsset)
        {
            GameControlsAsset.CameraMap.SetCallbacks(this);
        }

        #endregion

        #region Properties
        
        public Vector2 LookInputs { get; private set; }

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
        
        public void OnLook(InputAction.CallbackContext context)
        {
            LookInputs = context.ReadValue<Vector2>();
        }

        #endregion
    }
}