using System;
using Miscellaneous;
using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Statuses.Main
{
    public class Health : Status, IHealth, IDamageable
    {
        #region Events

        public event DelegateHolder.FloatEvents OnDamaged;
        public event Action OnDied;
        public event Action OnResurrected;

        #endregion

        #region Properties

        public override float CurrentValue
        {
            get => base.CurrentValue;
            protected set
            {
                var previousValue = CurrentValue;

                base.CurrentValue = value;

                CheckDamageEvent(previousValue, CurrentValue);
                CheckDeathEvent(previousValue, CurrentValue);
                CheckResurrectEvent(previousValue, CurrentValue);
            }
        }

        #endregion

        #region Methods

#if UNITY_EDITOR
        [ContextMenu("Test Add Health (20)")]
        private void TestAddHealth()
        {
            CurrentValue += 20;
        }
#endif

        public void ApplyDamage(Damage damage)
        {
            if (!(this as IHealth).Alive)
            {
                return;
            }

            CurrentValue -= damage.Value;
        }

        public bool TryHeal(float healValue)
        {
            if (!(this as IHealth).Alive)
            {
                return false;
            }

            CurrentValue += healValue;

            return true;
        }

        public void Resurrect()
        {
            CurrentValue = MaxValue;
        }

        private void CheckDeathEvent(float previousValue, float currentValue)
        {
            if (currentValue > 0f)
            {
                return;
            }

            if (previousValue <= 0f)
            {
                return;
            }
            
            OnDied?.Invoke();
        }

        private void CheckDamageEvent(float previousValue, float currentValue)
        {
            if (currentValue < 0f)
            {
                return;
            }

            if (previousValue <= 0f)
            {
                return;
            }
            
            OnDamaged?.Invoke(previousValue - currentValue);
        }

        private void CheckResurrectEvent(float previousValue, float currentValue)
        {
            if (previousValue > 0f)
            {
                return;
            }

            if (currentValue <= previousValue)
            {
                return;
            }

            OnResurrected?.Invoke();
        }

        #endregion
    }
}