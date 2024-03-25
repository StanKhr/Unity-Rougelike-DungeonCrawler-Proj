using Miscellaneous;
using Statuses.Datas;
using Statuses.Enums;
using Statuses.Interfaces;
using UnityEngine;

namespace Props.Projectiles.Feedbacks
{
    public class Arrow : ProjectileVictimFeedback
    {
        #region Editor Fields

        [SerializeField] private bool _damageOnce = true;
        [SerializeField] private Damage _damage = new()
        {
            Value = 15f,
            CritApplied = false,
            DamageType = DamageType.Arrow,
        };

        #endregion

        #region Fields

        private bool _damageApplied;

        #endregion

        #region Unity Callbacks

        protected override void OnEnable()
        {
            base.OnEnable();
            _damageApplied = false;
        }

        #endregion
        
        #region Methods

        protected override void VictimFoundCallback(EventContext.GameObjectEvent context)
        {
            if (_damageOnce && _damageApplied)
            {
                return;
            }
            
            if (!context.GameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                return;
            }

            _damageApplied = true;

            _damage.Source = gameObject;
            damageable.TryApplyDamage(_damage);
        }

        #endregion
    }
}