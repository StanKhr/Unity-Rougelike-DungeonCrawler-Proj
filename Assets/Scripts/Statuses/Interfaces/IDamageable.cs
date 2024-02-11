using System;
using Miscellaneous;
using Statuses.Datas;

namespace Statuses.Interfaces
{
    public interface IDamageable
    {
        #region Events

        event DelegateHolder.FloatEvents OnDamaged;

        #endregion
        
        #region Methods

        void ApplyDamage(Damage damage);

        #endregion
    }
}