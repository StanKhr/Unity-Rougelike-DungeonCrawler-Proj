using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Player.Interfaces;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class TimerComponent : MonoBehaviour, ITimer
    {
        #region Events
        
        public event Action OnTimerStarted;
        public event Action OnTimerCancelled;
        public event Action OnTimerEnded;

        #endregion
        
        #region Editor Fields

        [SerializeField] private float _seconds;

        #endregion

        #region Fields

        private CancellationTokenSource _cancellationTokenSource;

        #endregion

        #region Unity Callbacks

        private void OnDestroy()
        {
            _cancellationTokenSource?.Cancel();
        }

        #endregion

        #region Methods

        public bool TryStart()
        {
            if (_seconds <= 0f)
            {
                return false;
            }

            StartTimer();
            return true;
        }

        private async void StartTimer()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            
            OnTimerStarted?.Invoke();

            var delayMS = Mathf.RoundToInt(_seconds * 1000f);
            var cancelled = await UniTask.Delay(delayMS, cancellationToken: _cancellationTokenSource.Token)
                .SuppressCancellationThrow();
            if (cancelled)
            {
                OnTimerCancelled?.Invoke();
                return;
            }
            
            OnTimerEnded?.Invoke();
        }

        #endregion
    }
}