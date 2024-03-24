using System;
using System.Collections.Generic;
using System.Linq;
using Miscellaneous.CustomEvents.Interfaces;

namespace Miscellaneous.CustomEvents.Events
{
    public class ValueEvent<T> : IValueEvent<T> where T : struct
    {
        #region Constructors

        public ValueEvent()
        {
            
        }

        #endregion
        
        #region Properties

        private HashSet<Action<T>> Listeners { get; } = new HashSet<Action<T>>();

        #endregion

        #region Methods

        public bool AddListener(Action<T> listener)
        {
            return Listeners.Add(listener);
        }

        public bool RemoveListener(Action<T> listener)
        {
            return Listeners.Remove(listener);
        }

        public void ClearListeners()
        {
            Listeners.Clear();
        }

        public void NotifyListeners(T context)
        {
            var listenersList = Listeners.ToList();
            foreach (var listener in listenersList)
            {
                listener.Invoke(context);
            }
        }

        #endregion

        // #region Operators
        //
        // public static ValueEvent<T> operator +(ValueEvent<T> evn, Action<T> listener)
        // {
        //     evn.AddListener(listener);
        //
        //     return evn;
        // }
        //
        // public static ValueEvent<T> operator -(ValueEvent<T> evn, Action<T> listener)
        // {
        //     evn.RemoveListener(listener);
        //
        //     return evn;
        // }
        //
        // #endregion
    }
}