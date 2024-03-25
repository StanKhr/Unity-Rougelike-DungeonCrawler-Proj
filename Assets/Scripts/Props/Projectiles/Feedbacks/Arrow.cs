using Miscellaneous;
using Props.Projectiles.Components;
using Statuses.Datas;
using Statuses.Enums;
using Statuses.Interfaces;
using UnityEngine;

namespace Props.Projectiles.Feedbacks
{
    public class Arrow : ProjectileEventsListener
    {
        #region Editor Fields

        [SerializeField] private Damage _damage = new()
        {
            Value = 15f,
            CritApplied = false,
            DamageType = DamageType.Arrow,
        };
        
        [SerializeField] private ProjectileSimpleDamageable _projectileSimpleDamageable;

        #endregion

        #region Fields

        private bool _damageApplied;

        #endregion

        #region Properties

        protected override bool ListenVictimFoundEvent { get; } = true;
        private IDamageable Damageable => _projectileSimpleDamageable;

        #endregion

        #region Unity Callbacks

        protected override void OnEnable()
        {
            base.OnEnable();
            Damageable.OnDamaged.AddListener(DamagedCallback);
            
            _damageApplied = false;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Damageable.OnDamaged.RemoveListener(DamagedCallback);
        }

        #endregion
        
        #region Methods

        protected override void VictimFoundCallback(EventContext.GameObjectEvent context)
        {
            if (_damageApplied)
            {
                return;
            }
            
            if (context.GameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TryApplyDamage(_damage);
            }
            
            DestroyArrow();
        }

        private void DamagedCallback(EventContext.FloatEvent obj)
        {
            DestroyArrow();
        }

        private void DestroyArrow()
        {
            _damageApplied = true;
            Projectile.Destroy();
        }

        #endregion
    }
}