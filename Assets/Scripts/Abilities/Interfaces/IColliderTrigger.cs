using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;

namespace Abilities.Interfaces
{
    public interface IColliderTrigger
    {
        #region Events

        IContextEvent<EventContext.TriggerEnterEvent> OnEntered { get; }
        IContextEvent<EventContext.TriggerEnterEvent> OnLeft { get; }

        #endregion
    }
}