using System;
using Statuses.Datas;

namespace Statuses.Interfaces
{
    public interface IDefence
    {
        #region Events

        event Action OnDamageAbsorbed;

        #endregion
        
        #region Methods

        bool TryAbsorbDamage(Damage damage, out float remainingDamageValue);

        #endregion
    }
}