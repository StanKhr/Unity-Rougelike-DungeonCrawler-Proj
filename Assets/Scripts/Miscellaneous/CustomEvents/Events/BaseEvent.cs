using System;
using Miscellaneous.CustomEvents.Interfaces;

namespace Miscellaneous.CustomEvents.Events
{
    public class BaseEvent : IEvent
    {
        #region Events

        private event Action OnTriggered;

        #endregion
        
        #region Methods

        public bool AddCallback(Action callback)
        {
            OnTriggered += callback;
            return true;
        }

        public bool RemoveCallback(Action callback)
        {
            OnTriggered -= callback;
            return true;
        }

        public void ClearCallbacks()
        {
            OnTriggered = null;
        }

        public void Invoke()
        {
            OnTriggered?.Invoke();
        }

        #endregion
    }
}