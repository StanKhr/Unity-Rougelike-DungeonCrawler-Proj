using System;
using System.Collections.Generic;
using System.Linq;
using Miscellaneous.CustomEvents.Interfaces;
using UnityEngine;

namespace Miscellaneous.CustomEvents.Events
{
    public class CustomEvent : IEvent
    {
        #region Constructors

        public CustomEvent()
        {
            
        }

        #endregion

        #region Properties

        private HashSet<Action> Listeners { get; } = new();

        #endregion
        
        #region Methods

        public bool AddListener(Action listener)
        {
            return Listeners.Add(listener);
        }

        public bool RemoveListener(Action listener)
        {
            return Listeners.Remove(listener);
        }

        public void ClearListeners()
        {
            Listeners.Clear();
        }

        public void NotifyListeners()
        {
            var callbacksList = Listeners.ToList();
            foreach (var callback in callbacksList)
            {
                callback.Invoke();
            }
        }

        #endregion

        // #region Operators
        //
        // public static CustomEvent operator +(CustomEvent evn, Action callback)
        // {
        //     evn.AddListener(callback);
        //
        //     return evn;
        // }
        //
        // public static CustomEvent operator -(CustomEvent evn, Action callback)
        // {
        //     evn.RemoveListener(callback);
        //
        //     return evn;
        // }
        //
        // #endregion
    }
}