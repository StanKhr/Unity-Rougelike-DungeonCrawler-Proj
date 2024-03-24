using Miscellaneous.EventWrapper.Main;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class SimpleAnimations : InteractableCallbacksComponent
    {
        #region Constants

        private const float AnimationSpeedBase = 1.0f;
        private const float AnimationTransitionTime = 0.2f;
        private static readonly int StartHash = Animator.StringToHash("Start");
        private static readonly int EndHash = Animator.StringToHash("End");
        private static readonly int SpeedHash = Animator.StringToHash("Speed");

        #endregion

        #region Editor Fields

        [SerializeField] private bool _useStartCallback = true;
        [SerializeField] private bool _useEndCallback = true;
        [SerializeField] private float _animStartSpeed = AnimationSpeedBase;
        [SerializeField] private float _animEndSpeed = AnimationSpeedBase;
        [SerializeField] private Animator _animator;

        #endregion

        #region Properties

        protected override bool UseStartCallback => _useStartCallback;
        protected override bool UseEndCallback => _useEndCallback;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(Events.GameObjectEvent context)
        {
            _animator.SetFloat(SpeedHash, _animStartSpeed);
            _animator.CrossFade(StartHash, AnimationTransitionTime);
        }

        protected override void InteractionEndedCallback(Events.GameObjectEvent context)
        {
            _animator.SetFloat(SpeedHash, _animEndSpeed);
            _animator.CrossFade(EndHash, AnimationTransitionTime);
        }

        #endregion
    }
}