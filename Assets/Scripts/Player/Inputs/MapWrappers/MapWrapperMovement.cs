using System;
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
        
        #region Constants

        private const float GamepadMoveWalkMaxVelocity = 0.5f;

        #endregion

        #region Events
        
        public event Action OnJump;

        #endregion

        #region Properties
        public Vector2 MoveInputs { get; private set; }
        public bool Sprinting { get; private set; }
        public bool Crouching { get; private set; }
        public bool Walking { get; private set; }

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

            // Walking = MoveInputs.sqrMagnitude <= GamepadMoveWalkMaxVelocity;
        }

        void GameControlsAsset.IMovementMapActions.OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnJump?.Invoke();
        }

        void GameControlsAsset.IMovementMapActions.OnCrouch(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Crouching = true;
                return;
            }

            if (context.canceled)
            {
                Crouching = false;
            }
        }

        void GameControlsAsset.IMovementMapActions.OnSprint(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Sprinting = true;
                return;
            }

            if (context.canceled)
            {
                Sprinting = false;
            }
        }

        public void OnWalk(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Walking = true;
                return;
            }

            if (context.canceled)
            {
                Walking = false;
            }
        }

        #endregion
    }
}