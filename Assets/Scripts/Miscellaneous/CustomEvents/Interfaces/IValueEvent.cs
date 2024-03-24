using System;

namespace Miscellaneous.CustomEvents.Interfaces
{
    public interface IValueEvent<T> where T : struct
    {
        #region Methods

        public bool AddCallback(Action<T> callback);
        public bool RemoveCallback(Action<T> callback);
        public bool HasCallback(Action<T> callback);
        public void ClearCallbacks();
        public void Invoke(T context);

        #endregion
    }
}