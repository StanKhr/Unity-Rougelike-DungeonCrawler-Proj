using Miscellaneous;
using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using Player.GameStories.Datas;

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