using Miscellaneous;
using Player.GameStories.Datas;

namespace Player.GameStories.Interfaces
{
    public interface IStoryEvent
    {
        #region Events

        public static event DelegateHolder.StoryEventDataEvents OnTriggered;

        #endregion

        #region Interface Methods

        public void TriggerEvent(StoryEventData eventData)
        {
            OnTriggered?.Invoke(eventData);
        }

        #endregion
    }
}