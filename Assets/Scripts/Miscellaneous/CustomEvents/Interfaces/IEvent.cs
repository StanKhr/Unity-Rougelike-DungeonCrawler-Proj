using System;

namespace Miscellaneous.CustomEvents.Interfaces
{
    public interface IEvent
    {
        #region Methods

        public bool AddCallback(Action callback);
        public bool RemoveCallback(Action callback);
        public void ClearCallbacks();
        public void Invoke();

        #endregion
    }
}