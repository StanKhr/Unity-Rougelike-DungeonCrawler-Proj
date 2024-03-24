using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;

namespace Props.Interfaces
{
    public interface IInteractable
    {
        #region Events

        IContextEvent<EventContext.GameObjectEvent> OnInteractionStarted { get; }
        IContextEvent<EventContext.GameObjectEvent> OnInteractionEnded { get; }

        #endregion
    }
}