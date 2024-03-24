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

        private HashSet<Action<T>> Callbacks { get; } = new HashSet<Action<T>>();

        #endregion

        #region Methods

        public bool AddCallback(Action<T> callback)
        {
            return Callbacks.Add(callback);
        }

        public bool RemoveCallback(Action<T> callback)
        {
            return Callbacks.Remove(callback);
        }

        public bool HasCallback(Action<T> callback)
        {
            return Callbacks.Contains(callback);
        }

        public void ClearCallbacks()
        {
            Callbacks.Clear();
        }

        public void Invoke(T context)
        {
            var callbacksList = Callbacks.ToList();
            foreach (var callback in callbacksList)
            {
                callback.Invoke(context);
            }
        }

        #endregion

        #region Operators

        public static ValueEvent<T> operator +(ValueEvent<T> evn, Action<T> callback)
        {
            evn.AddCallback(callback);

            return evn;
        }

        public static ValueEvent<T> operator -(ValueEvent<T> evn, Action<T> callback)
        {
            evn.RemoveCallback(callback);

            return evn;
        }

        #endregion
    }
}