using Miscellaneous;
using Player.GameStories.Datas;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;

namespace Player.GameStories.Interfaces
{
    public interface IStoryEpisode
    {
        #region Events

        public static IContextEvent<EventContext.StoryEpisodeDataEvent> OnTriggered { get; } =
            EventFactory.CreateContextEvent<EventContext.StoryEpisodeDataEvent>();

        #endregion

        #region Interface Methods

        public void TriggerEvent(StoryEpisodeData episodeData)
        {
            OnTriggered?.NotifyListeners(new EventContext.StoryEpisodeDataEvent()
            {
                StoryEpisodeData = episodeData
            });
        }

        #endregion
    }
}