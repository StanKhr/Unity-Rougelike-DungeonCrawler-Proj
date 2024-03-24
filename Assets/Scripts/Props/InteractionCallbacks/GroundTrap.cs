using Miscellaneous.EventWrapper.Main;
using Props.Common;
using Props.Interfaces;
using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class GroundTrap : InteractableCallbacksBase
    {
        #region Editor Fields

        [SerializeField] private PressurePlate _pressurePlate;
        [SerializeField] private Damage _damage;

        #endregion

        #region Properties

        protected override bool UseStartCallback => true;
        protected override IInteractable Interactable => _pressurePlate;


        #endregion

        #region Methods

        protected override void InteractionStartedCallback(Events.GameObjectEvent context)
        {
            if (!context.GameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                return;
            }
            
            damageable.TryApplyDamage(_damage);
        }
        
        #endregion
    }
}