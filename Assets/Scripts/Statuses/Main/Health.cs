using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Statuses.Main
{
    public class Health : Status, IHealth, IDamageable
    {
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
            CurrentValue -= damage.Value;
        }

        #endregion
    }
}