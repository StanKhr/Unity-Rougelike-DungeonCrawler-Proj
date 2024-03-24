using Player.Inputs.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using Scripts.Player.Inputs;
using UnityEngine.InputSystem;

namespace Player.Inputs.MapWrappers
{
    public class MapWrapperAbilities : MapWrapper, GameControlsAsset.IAbilitiesMapActions, IMapWrapperAbilities
    {
        #region Constructors
        
        public MapWrapperAbilities(GameControlsAsset gameControlsAsset) : base(gameControlsAsset)
        {
            GameControlsAsset.AbilitiesMap.SetCallbacks(this);
        }

        #endregion

        #region Events

        public IEvent OnTestInputPressed { get; } = EventFactory.CreateEvent();
        public IEvent OnInteracted { get; } = EventFactory.CreateEvent();

        #endregion

        #region Properties

        public bool AttackInputHolding { get; private set; }

        #endregion

        #region Methods

        public void EnableMap(bool enable)
        {
            if (!enable)
            {
                GameControlsAsset.AbilitiesMap.Disable();
                return;
            }
            
            GameControlsAsset.AbilitiesMap.Enable();
        }

        void GameControlsAsset.IAbilitiesMapActions.OnInteract(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnInteracted?.NotifyListeners();
        }

        void GameControlsAsset.IAbilitiesMapActions.OnWeaponAttack(InputAction.CallbackContext context)
        {
            AttackInputHolding = context.ReadValue<float>() > 0f;
        }

        public void OnTest(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnTestInputPressed?.NotifyListeners();
        }

        #endregion
    }
}