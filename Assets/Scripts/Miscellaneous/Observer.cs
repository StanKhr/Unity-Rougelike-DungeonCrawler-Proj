using System;
using System.Collections.Generic;

namespace Miscellaneous
{
    public class Observer<T>
    {
        #region Fields

        private readonly List<Action<T>> _listeners = new();

        #endregion

        #region Methods

        public void AddListener(Action<T> action)
        {
            _listeners.Add(action);
        }

        public void RemoveListener(Action<T> action)
        {
            _listeners.Remove(action);
        }
        
        public void NotifyListeners(T context)
        {
            foreach (var listener in _listeners)
            {
                listener?.Invoke(context);
            }
        }

        #endregion
    }
}