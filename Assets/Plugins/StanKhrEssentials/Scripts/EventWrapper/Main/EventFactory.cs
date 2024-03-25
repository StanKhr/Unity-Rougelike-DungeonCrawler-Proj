using System;
using System.Collections.Generic;
using System.Linq;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Enums;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;

namespace Plugins.StanKhrEssentials.Scripts.EventWrapper.Main
{
    public static class EventFactory
    {
        #region Types
        
        private class EventCustom : IEvent
        {
            #region Constructors

            public EventCustom()
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
                if (Listeners.Count <= 0)
                {
                    return;
                }

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
        private class ContextEventCustom<T> : IContextEvent<T> where T : struct
        {
            #region Constructors

            public ContextEventCustom()
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
        private class EventBase : IEvent
        {
            #region Events

            private event Action OnTriggered;

            #endregion

            #region Methods

            public bool AddListener(Action listener)
            {
                OnTriggered += listener;
                return true;
            }

            public bool RemoveListener(Action listener)
            {
                OnTriggered -= listener;
                return true;
            }

            public void ClearListeners()
            {
                OnTriggered = null;
            }

            public void NotifyListeners()
            {
                OnTriggered?.Invoke();
            }

            #endregion
        }
        private class ContextEventBase<T> : IContextEvent<T> where T : struct
        {
            #region Events

            private event Action<T> OnTriggered;

            #endregion

            #region Methods

            public bool AddListener(Action<T> listener)
            {
                OnTriggered += listener;
                return true;
            }

            public bool RemoveListener(Action<T> listener)
            {
                OnTriggered -= listener;
                return true;
            }

            public void ClearListeners()
            {
                OnTriggered = null;
            }

            public void NotifyListeners(T context)
            {
                OnTriggered?.Invoke(context);
            }

            #endregion
        }

        #endregion

        #region Methods

        public static IEvent CreateEvent(EventType eventType = EventType.Custom)
        {
            return eventType switch
            {
                EventType.Default => new EventBase(),
                EventType.Custom => new EventCustom(),
                _ => null
            };
        }

        public static IContextEvent<T> CreateContextEvent<T>(EventType eventType = EventType.Custom) where T : struct
        {
            return eventType switch
            {
                EventType.Default => new ContextEventBase<T>(),
                EventType.Custom => new ContextEventCustom<T>(),
                _ => null
            };
        }

        #endregion
    }
}