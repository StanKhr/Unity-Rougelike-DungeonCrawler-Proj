using UnityEngine;

namespace Statuses.Feedbacks.Defence
{
    public class DefenceFeedbackAnimations : DefenceFeedback
    {
        #region Constants

        private static readonly int DamageAbsorbedAnimHash = Animator.StringToHash("Damage Absorbed");

        #endregion
        
        #region Editor Fields

        [SerializeField] private Animator _animator;

        #endregion

        #region Methods
        
        protected override void DamageAbsorbedCallback()
        {
            _animator.Play(DamageAbsorbedAnimHash);
        }

        #endregion
    }
}