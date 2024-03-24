using System;
using System.Collections.Generic;

namespace Miscellaneous.CustomEvents.Events
{
    public class SimpleEvent
    {
        #region Constructors

        public SimpleEvent()
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
            foreach (var callback in Callbacks)
            {
                callback.Invoke();
            }
        }

        #endregion

        #region Operators

        public static SimpleEvent operator +(SimpleEvent evn, Action callback)
        {
            evn.AddCallback(callback);

            return evn;
        }

        public static SimpleEvent operator -(SimpleEvent evn, Action callback)
        {
            evn.RemoveCallback(callback);

            return evn;
        }

        #endregion
    }
}