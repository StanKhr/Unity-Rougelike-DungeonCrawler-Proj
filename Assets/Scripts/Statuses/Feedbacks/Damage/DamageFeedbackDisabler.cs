using System.Threading;
using Player.Interfaces;
using Player.Miscellaneous;
using UI.Utility;
using UnityEngine;

namespace Statuses.Feedbacks.Damage
{
    public class DamageFeedbackDisabler : DamageFeedback
    {
        #region Editor Fields

        [SerializeField] private TimerComponent _timer;

        #endregion

        #region Fields

        private CancellationTokenSource _cancellationTokenSource;

        #endregion

        #region Properties

        private ITimer Timer => _timer;

        #endregion

        #region Unity Callbacks

        protected override void OnEnable()
        {
            base.OnEnable();

            Timer.OnTimerEnded += TimerEndedCallback;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            Timer.OnTimerEnded -= TimerEndedCallback;
        }

        #endregion
        
        #region Methods

        protected override void DamagedCallback(float context)
        {
            if (Health.Alive)
            {
                return;
            }

            if (!Timer.TryStart())
            {
                gameObject.SetActiveSmart(false);
            }
        }

        protected virtual void TimerEndedCallback()
        {
            gameObject.SetActiveSmart(false);
        }

        #endregion
    }
}