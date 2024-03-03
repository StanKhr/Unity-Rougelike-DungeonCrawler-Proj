using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;

namespace Statuses.Feedbacks.Damage
{
    public abstract class DamageFeedback : MonoBehaviour
    {
        #region Fields

        private IDamageable _damageable;
        private IHealth _health;

        #endregion
        
        #region Properties

        protected virtual IDamageable Damageable => _damageable ??= GetComponent<IDamageable>();
        protected virtual IHealth Health => _health ??= GetComponent<IHealth>();
        
        protected virtual bool ObserveDamage { get; } = true;
        protected virtual bool ObserveDeath { get; } = false;

        #endregion

        #region Unity Callbacks

        protected virtual void OnEnable()
        {
            if (ObserveDamage)
            {
                Damageable.OnDamaged += DamagedCallback;
            }
            
            if (ObserveDeath)
            {
                Health.OnDied += DiedCallback;
            }
        }

        protected virtual void OnDisable()
        {
            if (ObserveDamage)
            {
                Damageable.OnDamaged -= DamagedCallback;
            }
            
            if (ObserveDeath)
            {
                Health.OnDied -= DiedCallback;
            }
        }

        #endregion
        
        #region Methods

        protected abstract void DamagedCallback(float context);
        protected virtual void DiedCallback()
        {
            
        }


        #endregion
    }
}