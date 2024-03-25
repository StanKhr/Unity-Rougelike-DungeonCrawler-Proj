using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;

namespace Player.Interfaces
{
    public interface IGameStory
    {
        #region Events

        public IContextEvent<EventContext.StringEvent> OnStoryUpdated { get; }

        #endregion
    }
}