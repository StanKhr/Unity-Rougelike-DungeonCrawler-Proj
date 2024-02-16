using System;
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