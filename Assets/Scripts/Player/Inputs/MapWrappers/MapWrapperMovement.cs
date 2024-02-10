using System;
using Miscellaneous;
using Player.Inputs.Interfaces;
using Scripts.Player.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Inputs.MapWrappers
{
    public class MapWrapperMovement : MapWrapper, IMapWrapperMovement, GameControlsAsset.IMovementMapActions
    {
        #region Constructors
        
        public MapWrapperMovement(GameControlsAsset gameControlsAsset) : base(gameControlsAsset)
        {
            GameControlsAsset.MovementMap.AddCallbacks(this);
        }

        #endregion

        #region Events
        
        public event Action OnJump;

        #endregion

        #region Properties
        public Vector2 MoveInputs { get; private set; }

        #endregion

        #region Methods

        public void EnableMap(bool enable)
        {
            if (!enable)
            {
                GameControlsAsset.MovementMap.Disable();
                return;
            }
            
            GameControlsAsset.MovementMap.Enable();
        }

        void GameControlsAsset.IMovementMapActions.OnMove(InputAction.CallbackContext context)
        {
            MoveInputs = context.ReadValue<Vector2>();
        }

        void GameControlsAsset.IMovementMapActions.OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnJump?.Invoke();
        }

        #endregion
    }
}