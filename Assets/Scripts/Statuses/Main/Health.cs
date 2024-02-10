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
                if (CurrentValue > 0f && value < CurrentValue)
                {
                    var damageAmount = CurrentValue - value;
                    OnDamaged?.Invoke(damageAmount);
                }

                base.CurrentValue = value;
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
            if (CurrentValue == 0f)
            {
                return;
            }
            
            CurrentValue -= damage.Value;
        }

        #endregion
    }
}