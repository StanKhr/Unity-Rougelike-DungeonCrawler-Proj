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

        #endregion

        #region Properties

        public override float CurrentValue
        {
            get => base.CurrentValue;
            protected set
            {
                var current = CurrentValue;

                base.CurrentValue = value;
                
                if (current > 0f && value < current)
                {
                    var damageAmount = CurrentValue - value;
                    OnDamaged?.Invoke(damageAmount);
                }
            }
        }

        public bool Alive => CurrentValue > 0f;

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
            if (!Alive)
            {
                return;
            }
            
            CurrentValue -= damage.Value;
        }
        
        public bool TryHeal(float healValue)
        {
            if (!Alive)
            {
                return false;
            }

            CurrentValue += healValue;

            return true;
        }

        #endregion
    }
}