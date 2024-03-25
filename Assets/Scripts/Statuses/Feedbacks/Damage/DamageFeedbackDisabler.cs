using System.Threading;
using Miscellaneous;
using Player.Interfaces;
using Player.Miscellaneous;
using UI.Utility;
using UnityEngine;

namespace Statuses.Feedbacks.Damage
{
    public class DamageFeedbackDisabler : DamageFeedback
    {
        #region Editor Fields

        [SerializeField] private GameObject _specificTarget;
        [SerializeField] private TimerComponent _timer;

        #endregion

        #region Properties

        private ITimer Timer => _timer;
        protected GameObject Target => _specificTarget ? _specificTarget : gameObject;

        #endregion

        #region Unity Callbacks

        protected override void OnEnable()
        {
            base.OnEnable();

            Timer?.OnTimerEnded.AddListener(TimerEndedCallback);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            Timer?.OnTimerEnded.RemoveListener(TimerEndedCallback);
        }

        #endregion
        
        #region Methods

        protected override void DamagedCallback(EventContext.FloatEvent context)
        {
            if (Health.Alive)
            {
                return;
            }

            if (Timer == null)
            {
                ApplyDeathEffect();
                return;
            }

            if (!Timer.TryStart())
            {
                ApplyDeathEffect();
            }
        }

        private void TimerEndedCallback()
        {
            ApplyDeathEffect();
        }

        protected virtual void ApplyDeathEffect()
        {
            Target.SetActiveSmart(false);
        }

        #endregion
    }
}