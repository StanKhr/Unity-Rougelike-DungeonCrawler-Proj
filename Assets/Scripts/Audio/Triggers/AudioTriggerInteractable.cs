using Audio.ClipSelectors;
using Props.InteractionCallbacks;
using Props.Interfaces;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerInteractable : InteractableCallbacksComponent
    {
        #region Editor Fields

        [field: SerializeField] protected AudioSource AudioSource { get; private set; }
        [SerializeField] private ClipSelector _clipSelectorInteractionStarted;
        [SerializeField] private ClipSelector _clipSelectorInteractionEnded;

        #endregion
        
        #region Fields

        private IInteractable _interactable;

        #endregion

        #region Properties

        protected override bool UseStartCallback => _clipSelectorInteractionStarted;
        protected override bool UseEndCallback => _clipSelectorInteractionEnded;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(GameObject context)
        {
            if (!_clipSelectorInteractionStarted)
            {
                return;
            }
            
            _clipSelectorInteractionStarted.TryOneShotAudioSource(AudioSource);
        }

        protected override void InteractionEndedCallback(GameObject context)
        {
            if (!_clipSelectorInteractionEnded)
            {
                return;
            }
            
            _clipSelectorInteractionEnded.TryOneShotAudioSource(AudioSource);
        }

        #endregion
    }
}