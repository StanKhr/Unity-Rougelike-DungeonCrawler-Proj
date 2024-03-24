using Miscellaneous.EventWrapper.Main;
using UnityEngine;

namespace Statuses.Feedbacks.Damage
{
    public class DamageFeedbackAnimations : DamageFeedback
    {
        #region Constants

        private static readonly int DamagedHash = Animator.StringToHash("Damaged");
        private static readonly int KilledHash = Animator.StringToHash("Killed");
        // private static readonly int ResurrectedHash = Animator.StringToHash("Resurrected");

        #endregion

        #region Editor Fields

        [SerializeField] private Animator _animator;

        #endregion

        #region Methods
        
        protected override void DamagedCallback(Events.FloatEvent context)
        {
            _animator.Play(DamagedHash);
            
            if (Health.Alive)
            {
                return;
            }
            
            _animator.Play(KilledHash);
        }

        #endregion
    }
}