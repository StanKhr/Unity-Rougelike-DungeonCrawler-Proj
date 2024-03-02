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

        bool TryApplyDamage(Damage damage);

        #endregion
    }
}