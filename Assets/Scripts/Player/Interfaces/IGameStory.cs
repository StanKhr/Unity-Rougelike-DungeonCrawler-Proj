using Miscellaneous;

namespace Player.Interfaces
{
    public interface IGameStory
    {
        #region Events

        public event DelegateHolder.StringEvents OnStoryUpdated;

        #endregion
    }
}