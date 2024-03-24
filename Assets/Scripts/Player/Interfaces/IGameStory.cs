using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;

namespace Player.Interfaces
{
    public interface IGameStory
    {
        #region Events

        public IContextEvent<Events.StringEvent> OnStoryUpdated { get; }

        #endregion
    }
}