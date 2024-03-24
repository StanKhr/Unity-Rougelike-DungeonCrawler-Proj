﻿using System;
using Miscellaneous.EventWrapper.Enums;
using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;

namespace Miscellaneous.EventWrapper.Main
{
    public static class EventFactory
    {
        #region Types

        

        #endregion
        
        #region Methods

        public static IEvent CreateEvent(EventType type = EventType.Custom)
        {
            return type switch
            {
                EventType.Default => new BaseEvent(),
                EventType.Custom => new CustomEvent(),
                _ => null
            };
        }

        public static IContextEvent<T> CreateContextEvent<T>(EventType type = EventType.Custom) where T : struct
        {
            return type switch
            {
                EventType.Default => null,
                EventType.Custom => new ContextEvent<T>(),
                _ => null
            };
        }

        #endregion
    }
}