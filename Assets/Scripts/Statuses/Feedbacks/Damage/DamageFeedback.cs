using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;

namespace Statuses.Feedbacks.Damage
{
    public abstract class DamageFeedback : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Health _health;

        #endregion

        #region Properties

        protected IDamageable Damageable => _health;
        protected IHealth Health => _health;
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