using Props.Interfaces;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class SimpleAnimations : InteractableCallbacksComponent
    {
        #region Constants

        private const float AnimationTransitionTime = 0.2f;
        private static readonly int StartHash = Animator.StringToHash("Start");
        private static readonly int EndHash = Animator.StringToHash("End");

        #endregion

        #region Editor Fields

        [SerializeField] private bool _useStartCallback = true;
        [SerializeField] private bool _useEndCallback = true;
        [SerializeField] private Animator _animator;

        #endregion

        #region Properties

        protected override bool UseStartCallback => _useStartCallback;
        protected override bool UseEndCallback => _useEndCallback;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(GameObject context)
        {
            _animator.CrossFade(StartHash, AnimationTransitionTime);
        }

        protected override void InteractionEndedCallback(GameObject context)
        {
            _animator.CrossFade(EndHash, AnimationTransitionTime);
        }

        #endregion
    }
}