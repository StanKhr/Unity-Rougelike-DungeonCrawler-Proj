﻿using System;

namespace Player.Interfaces
{
    public interface ITimer
    {
        #region Events

        event Action OnTimerStarted;
        event Action OnTimerCancelled;
        event Action OnTimerEnded;

        #endregion

        #region Properties

        bool InProgress { get; }

        #endregion
        
        #region Methods

        bool TryStart();

        #endregion
    }
}