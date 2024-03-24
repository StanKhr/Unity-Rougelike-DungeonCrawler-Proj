using Miscellaneous;
using Player.GameStories.Datas;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;

namespace Player.GameStories.Interfaces
{
    public interface IStoryEpisode
    {
        #region Events

        public static IContextEvent<Events.StoryEpisodeDataEvent> OnTriggered { get; } =
            new ContextEvent<Events.StoryEpisodeDataEvent>();

        #endregion

        #region Interface Methods

        public void TriggerEvent(StoryEpisodeData episodeData)
        {
            OnTriggered?.NotifyListeners(new Events.StoryEpisodeDataEvent()
            {
                StoryEpisodeData = episodeData
            });
        }

        #endregion
    }
}