using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using Statuses.Datas;

namespace Statuses.Interfaces
{
    public interface IDamageable
    {
        #region Events

        IContextEvent<Events.FloatEvent> OnDamaged { get; }

        #endregion
        
        #region Methods

        bool TryApplyDamage(Damage damage);

        #endregion
    }
}