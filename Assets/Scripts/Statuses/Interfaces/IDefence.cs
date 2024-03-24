using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Statuses.Datas;

namespace Statuses.Interfaces
{
    public interface IDefence
    {
        #region Events

        IEvent OnDamageAbsorbed { get; }

        #endregion
        
        #region Methods

        bool TryAbsorbDamage(Damage damage, out float remainingDamageValue);

        #endregion
    }
}