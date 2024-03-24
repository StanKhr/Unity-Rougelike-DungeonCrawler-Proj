using System;
using Player.Inputs.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
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

        public IEvent OnInventory { get; } = new CustomEvent();
        public IEvent OnPauseMenu { get; } = new CustomEvent();
        public IEvent OnDiscardPressed { get; } = new CustomEvent();

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
            
            OnInventory?.NotifyListeners();
        }

        void GameControlsAsset.IUtilityMapActions.OnPauseMenu(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnPauseMenu?.NotifyListeners();
        }

        void GameControlsAsset.IUtilityMapActions.OnDiscard(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnDiscardPressed?.NotifyListeners();
        }

        #endregion

    }
}