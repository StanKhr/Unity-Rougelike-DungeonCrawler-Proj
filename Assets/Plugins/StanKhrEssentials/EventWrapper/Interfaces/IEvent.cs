using System;

namespace Plugins.StanKhrEssentials.EventWrapper.Interfaces
{
    public interface IEvent
    {
        #region Methods

        public bool AddListener(Action listener);
        public bool RemoveListener(Action listener);
        public void ClearListeners();
        public void NotifyListeners();

        #endregion
    }
}