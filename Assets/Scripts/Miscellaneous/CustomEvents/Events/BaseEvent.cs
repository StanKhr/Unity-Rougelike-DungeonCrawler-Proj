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

        public bool AddListener(Action listener)
        {
            OnTriggered += listener;
            return true;
        }

        public bool RemoveListener(Action listener)
        {
            OnTriggered -= listener;
            return true;
        }

        public void ClearListeners()
        {
            OnTriggered = null;
        }

        public void NotifyListeners()
        {
            OnTriggered?.Invoke();
        }

        #endregion
    }
}