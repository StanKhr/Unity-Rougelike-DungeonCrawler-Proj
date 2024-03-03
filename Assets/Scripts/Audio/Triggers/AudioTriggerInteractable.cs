using Audio.ClipSelectors;
using Audio.Interfaces;
using Props.InteractionCallbacks;
using Props.Interfaces;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerInteractable : InteractableCallbacksComponent
    {
        #region Editor Fields

        [field: SerializeField] protected AudioSource AudioSource { get; private set; }
        [SerializeField] private ClipSelectorScriptable _clipSelectorInteractionStarted;
        [SerializeField] private ClipSelectorScriptable _clipSelectorInteractionEnded;

        #endregion
        
        #region Fields

        private IInteractable _interactable;

        #endregion

        #region Properties

        private IClipSelector ClipSelectorInteractionStarted => _clipSelectorInteractionStarted;
        private IClipSelector ClipSelectorInteractionEnded => _clipSelectorInteractionEnded;
        protected override bool UseStartCallback => _clipSelectorInteractionStarted;
        protected override bool UseEndCallback => _clipSelectorInteractionEnded;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(GameObject context)
        {
            ClipSelectorInteractionStarted?.TryOneShotOnAudioSource(AudioSource);
        }

        protected override void InteractionEndedCallback(GameObject context)
        {
            ClipSelectorInteractionEnded?.TryOneShotOnAudioSource(AudioSource);
        }

        #endregion
    }
}