using Statuses.Datas;

namespace Statuses.Interfaces
{
    public interface IDamageable
    {
        #region Methods

        void TakeDamage(Damage damage);

        #endregion
    }
}