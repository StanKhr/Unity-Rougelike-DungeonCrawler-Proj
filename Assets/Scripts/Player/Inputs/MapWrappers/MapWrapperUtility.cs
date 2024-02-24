using System;
using Player.Inputs.Interfaces;
using Scripts.Player.Inputs;
using UnityEngine.InputSystem;

namespace Player.Inputs.MapWrappers
{
    public class MapWrapperUtility : MapWrapper, IMapWrapperUtility, GameControlsAsset.IUtilityMapActions
    {
        #region Constructors
        
        public MapWrapperUtility(GameControlsAsset gameControlsAsset) : base(gameControlsAsset)
        {
            gameControlsAsset.UtilityMap.SetCallbacks(this);
            EnableMap(true);
        }

        #endregion

        #region Events

        public event Action OnInventory;
        public event Action OnPauseMenu;
        public event Action OnDiscardPressed;

        #endregion

        #region Methods
        
        public void EnableMap(bool enable)
        {
            if (enable)
            {
                GameControlsAsset.UtilityMap.Enable();
                return;
            }
            
            GameControlsAsset.UtilityMap.Disable();
        }

        void GameControlsAsset.IUtilityMapActions.OnOpenInventory(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnInventory?.Invoke();
        }

        void GameControlsAsset.IUtilityMapActions.OnPauseMenu(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnPauseMenu?.Invoke();
        }

        void GameControlsAsset.IUtilityMapActions.OnDiscard(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnDiscardPressed?.Invoke();
        }

        #endregion

    }
}