using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Statuses.Main
{
    public class Health : Status, IHealth, IDamageable
    {
        #region Methods

        public void TakeDamage(Damage damage)
        {
            
        }

        #endregion
    }
}