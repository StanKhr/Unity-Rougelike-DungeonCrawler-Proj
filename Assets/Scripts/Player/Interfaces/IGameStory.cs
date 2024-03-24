using Miscellaneous;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;

namespace Player.Interfaces
{
    public interface IGameStory
    {
        #region Events

        public IContextEvent<Events.StringEvent> OnStoryUpdated { get; }

        #endregion
    }
}