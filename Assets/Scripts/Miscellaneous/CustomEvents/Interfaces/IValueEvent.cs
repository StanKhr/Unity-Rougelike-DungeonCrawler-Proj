using System;

namespace Miscellaneous.CustomEvents.Interfaces
{
    public interface IValueEvent<T> where T : struct
    {
        #region Methods

        public bool AddListener(Action<T> listener);
        public bool RemoveListener(Action<T> listener);
        public void ClearListeners();
        public void NotifyListeners(T context);

        #endregion
    }
}