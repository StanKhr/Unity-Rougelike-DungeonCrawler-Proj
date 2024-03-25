using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Statuses.Datas;

namespace Statuses.Interfaces
{
    public interface IDamageable
    {
        #region Events

        IContextEvent<EventContext.FloatEvent> OnDamaged { get; }

        #endregion
        
        #region Methods

        bool TryApplyDamage(Damage damage);

        #endregion
    }
}