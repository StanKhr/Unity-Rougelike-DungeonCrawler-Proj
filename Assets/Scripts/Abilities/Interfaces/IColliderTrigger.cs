using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;

namespace Abilities.Interfaces
{
    public interface IColliderTrigger
    {
        #region Events

        IContextEvent<EventContext.ColliderEvent> OnEntered { get; }
        IContextEvent<EventContext.ColliderEvent> OnLeft { get; }

        #endregion
    }
}