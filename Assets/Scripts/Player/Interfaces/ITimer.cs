using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;

namespace Player.Interfaces
{
    public interface ITimer
    {
        #region Events

        IEvent OnTimerStarted { get; }
        IEvent OnTimerCancelled { get; }
        IEvent OnTimerEnded { get; }

        #endregion

        #region Properties

        bool InProgress { get; }

        #endregion
        
        #region Methods

        bool TryStart();

        #endregion
    }
}