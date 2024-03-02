using Miscellaneous;
using UnityEngine;

namespace Props.Common
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
        
        protected override void DamagedCallback(float context)
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