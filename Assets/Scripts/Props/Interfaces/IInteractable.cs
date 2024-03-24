using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;

namespace Props.Interfaces
{
    public interface IInteractable
    {
        #region Events

        IContextEvent<Events.GameObjectEvent> OnInteractionStarted { get; }
        IContextEvent<Events.GameObjectEvent> OnInteractionEnded { get; }

        #endregion
    }
}