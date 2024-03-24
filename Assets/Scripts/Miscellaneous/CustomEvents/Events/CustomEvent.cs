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

        private HashSet<Action> Callbacks { get; } = new();

        #endregion
        
        #region Methods

        public bool AddCallback(Action callback)
        {
            return Callbacks.Add(callback);
        }

        public bool RemoveCallback(Action callback)
        {
            return Callbacks.Remove(callback);
        }

        public bool HasCallback(Action callback)
        {
            return Callbacks.Contains(callback);
        }

        public void ClearCallbacks()
        {
            Callbacks.Clear();
        }

        public void Invoke()
        {
            var callbacksList = Callbacks.ToList();
            foreach (var callback in callbacksList)
            {
                callback.Invoke();
            }
        }

        #endregion

        #region Operators

        public static CustomEvent operator +(CustomEvent evn, Action callback)
        {
            evn.AddCallback(callback);

            return evn;
        }

        public static CustomEvent operator -(CustomEvent evn, Action callback)
        {
            evn.RemoveCallback(callback);

            return evn;
        }

        #endregion
    }
}