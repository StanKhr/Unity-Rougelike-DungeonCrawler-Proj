using System;
using Audio.ClipSelectors;
using Props.Interfaces;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerInteractable : AudioTrigger
    {
        #region Editor Fields

        [SerializeField] private ClipSelector _clipSelectorInteractionStarted;
        [SerializeField] private ClipSelector _clipSelectorInteractionEnded;

        #endregion
        
        #region Fields

        private IInteractable _interactable;

        #endregion
        
        #region Properties

        private IInteractable Interactable => _interactable ??= GetComponent<IInteractable>();

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            Interactable.OnInteractionStarted += InteractionStartedCallback;
            Interactable.OnInteractionEnded += InteractionEndedCallback;
        }

        private void OnDisable()
        {
            Interactable.OnInteractionStarted -= InteractionStartedCallback;
            Interactable.OnInteractionEnded -= InteractionEndedCallback;
        }

        #endregion

        #region Methods
        
        private void InteractionStartedCallback(GameObject context)
        {
            if (!_clipSelectorInteractionStarted)
            {
                return;
            }
            
            _clipSelectorInteractionStarted.TryOneShotAudioSource(AudioSource);
        }

        private void InteractionEndedCallback(GameObject context)
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