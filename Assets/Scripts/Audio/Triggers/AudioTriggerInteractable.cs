using System;
using Audio.ClipSelectors;
using Audio.Interfaces;
using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Main;
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

        private IClipSelector ClipSelectorInteractionStarted => _clipSelectorInteractionStarted;
        private IClipSelector ClipSelectorInteractionEnded => _clipSelectorInteractionEnded;
        protected override bool UseStartCallback => _clipSelectorInteractionStarted;
        protected override bool UseEndCallback => _clipSelectorInteractionEnded;

        #endregion

        #region Methods

        protected override void InteractionStartedCallback(Events.GameObjectEvent context)
        {
            ClipSelectorInteractionStarted?.TryOneShotOnAudioSource(AudioSource);
        }

        protected override void InteractionEndedCallback(Events.GameObjectEvent context)
        {
            ClipSelectorInteractionEnded?.TryOneShotOnAudioSource(AudioSource);
        }

        #endregion
    }
}