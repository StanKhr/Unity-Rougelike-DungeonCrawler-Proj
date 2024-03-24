using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;

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