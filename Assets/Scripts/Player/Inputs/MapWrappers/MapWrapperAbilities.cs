using System;
using Miscellaneous;
using Player.Inputs.Interfaces;
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
        
        public event Action OnTestInputPressed;
        public event Action OnInteracted;
        public event DelegateHolder.BoolEvents OnWeaponAttackInputStateChanged;

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
            
            OnInteracted?.Invoke();
        }

        void GameControlsAsset.IAbilitiesMapActions.OnWeaponAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnWeaponAttackInputStateChanged?.Invoke(true);
                return;
            }

            if (context.canceled)
            {
                OnWeaponAttackInputStateChanged?.Invoke(false);
                return;
            }
        }

        public void OnTest(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnTestInputPressed?.Invoke();
        }

        #endregion
    }
}