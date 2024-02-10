using Statuses.Datas;

namespace Statuses.Interfaces
{
    public interface IDamageable
    {
        #region Methods

        void ApplyDamage(Damage damage);

        #endregion
    }
}