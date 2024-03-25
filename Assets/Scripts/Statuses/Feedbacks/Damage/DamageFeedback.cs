using System;
using Miscellaneous;
using Statuses.Interfaces;
using UnityEngine;

namespace Statuses.Feedbacks.Damage
{
    public abstract class DamageFeedback : MonoBehaviour
    {
        #region Properties

        protected virtual IDamageable Damageable { get; private set; }
        protected virtual IHealth Health { get; private set; }
        protected virtual bool ObserveDamage { get; } = true;
        protected virtual bool ObserveDeath { get; } = false;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            Damageable = GetComponent<IDamageable>();
            Health = GetComponent<IHealth>();
        }

        protected virtual void OnEnable()
        {
            if (ObserveDamage)
            {
                Damageable?.OnDamaged.AddListener(DamagedCallback);
            }
            
            if (ObserveDeath)
            {
                Health?.OnDied.AddListener(DiedCallback);
            }
        }

        protected virtual void OnDisable()
        {
            if (ObserveDamage)
            {
                Damageable?.OnDamaged.RemoveListener(DamagedCallback);
            }
            
            if (ObserveDeath)
            {
                Health?.OnDied.RemoveListener(DiedCallback);
            }
        }

        #endregion
        
        #region Methods

        protected virtual void DamagedCallback(EventContext.FloatEvent context)
        {
            
        }
        protected virtual void DiedCallback()
        {
            
        }


        #endregion
    }
}