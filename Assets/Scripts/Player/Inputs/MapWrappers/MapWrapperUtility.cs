using Player.Inputs.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
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

        public IEvent OnInventory { get; } = EventFactory.CreateEvent();
        public IEvent OnPauseMenu { get; } = EventFactory.CreateEvent();
        public IEvent OnDiscardPressed { get; } = EventFactory.CreateEvent();

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