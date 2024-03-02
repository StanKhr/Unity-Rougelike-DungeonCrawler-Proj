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

        #endregion

        #region Unity Callbacks

        protected virtual void OnEnable()
        {
            Damageable.OnDamaged += DamagedCallback;
        }

        protected virtual void OnDisable()
        {
            Damageable.OnDamaged -= DamagedCallback;
        }

        #endregion
        
        #region Methods

        protected abstract void DamagedCallback(float context);

        #endregion
    }
}