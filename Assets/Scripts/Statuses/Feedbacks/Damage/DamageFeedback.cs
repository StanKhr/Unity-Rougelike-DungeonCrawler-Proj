using Miscellaneous;
using Statuses.Interfaces;
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
                Damageable.OnDamaged.AddListener(DamagedCallback);
            }
            
            if (ObserveDeath)
            {
                Health.OnDied.AddListener(DiedCallback);
            }
        }

        protected virtual void OnDisable()
        {
            if (ObserveDamage)
            {
                Damageable.OnDamaged.RemoveListener(DamagedCallback);
            }
            
            if (ObserveDeath)
            {
                Health.OnDied.RemoveListener(DiedCallback);
            }
        }

        #endregion
        
        #region Methods

        protected abstract void DamagedCallback(EventContext.FloatEvent context);
        protected virtual void DiedCallback()
        {
            
        }


        #endregion
    }
}