using System;
using System.Collections.Generic;
using System.Linq;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;

namespace Plugins.StanKhrEssentials.EventWrapper.Events
{
    public class ContextEvent<T> : IContextEvent<T> where T : struct
    {
        #region Constructors

        public ContextEvent()
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
            if (Listeners.Count <= 0)
            {
                return;
            }

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