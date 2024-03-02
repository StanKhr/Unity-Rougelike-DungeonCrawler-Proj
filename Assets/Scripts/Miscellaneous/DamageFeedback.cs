using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;

namespace Miscellaneous
{
    public abstract class DamageFeedback : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Health _health;

        #endregion

        #region Properties

        protected IDamageable Damageable => _health;
        protected IHealth Health => _health;
        protected virtual bool ObserveDeath { get; } = false;

        #endregion

        #region Unity Callbacks

        protected virtual void OnEnable()
        {
            Damageable.OnDamaged += DamagedCallback;
            if (ObserveDeath)
            {
                Health.OnDied += DiedCallback;
            }
        }

        protected virtual void OnDisable()
        {
            Damageable.OnDamaged -= DamagedCallback;
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