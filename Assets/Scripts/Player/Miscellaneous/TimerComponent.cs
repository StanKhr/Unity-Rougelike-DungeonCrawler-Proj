using Cysharp.Threading.Tasks;
using Player.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class TimerComponent : CancellationTokenMonoComponent, ITimer
    {
        #region Events

        public IEvent OnTimerStarted { get; } = EventFactory.CreateEvent();
        public IEvent OnTimerCancelled { get; } = EventFactory.CreateEvent();
        public IEvent OnTimerEnded { get; } = EventFactory.CreateEvent();

        #endregion
        
        #region Editor Fields

        [SerializeField] private float _seconds;

        #endregion

        #region Fields

        private bool _inProgress;

        #endregion

        #region Properties

        public bool InProgress
        {
            get => _inProgress;
            private set
            {
                // if (InProgress == value)
                // {
                //     return;
                // }

                _inProgress = value;

                if (InProgress)
                {
                    OnTimerStarted?.NotifyListeners();
                    return;
                }
                
                OnTimerEnded?.NotifyListeners();
            }
        }

        #endregion

        #region Methods


        public bool TryStart()
        {
            return TryStartCustomTime(_seconds);
        }

        public bool TryStartCustomTime(float time)
        {
            if (time <= 0f)
            {
                return false;
            }

            StartTimer(time);
            return true;
        }

        public bool TryInterrupt()
        {
            if (!InProgress)
            {
                return false;
            }
            
            CancelToken();

            return true;
        }

        private async void StartTimer(float timeSeconds)
        {
            var token = RecreateToken();
            
            InProgress = true;

            var delayMS = Mathf.RoundToInt(timeSeconds * 1000f);
            var cancelled = await UniTask.Delay(delayMS, cancellationToken: token)
                .SuppressCancellationThrow();
            if (cancelled)
            {
                OnTimerCancelled?.NotifyListeners();
                return;
            }

            InProgress = false;
        }

        #endregion
    }
}