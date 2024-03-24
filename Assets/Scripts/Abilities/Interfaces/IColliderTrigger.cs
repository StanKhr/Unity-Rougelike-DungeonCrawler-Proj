using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;

namespace Abilities.Interfaces
{
    public interface IColliderTrigger
    {
        #region Events

        IContextEvent<Events.ColliderEvent> OnEntered { get; }
        IContextEvent<Events.ColliderEvent> OnLeft { get; }

        #endregion
    }
}