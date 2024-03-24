using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;

namespace Player.Interfaces
{
    public interface IGameStory
    {
        #region Events

        public IContextEvent<EventContext.StringEvent> OnStoryUpdated { get; }

        #endregion
    }
}