using System;
using Audio.ClipSelectors;
using UI.Utility;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerUiEvents : AudioTrigger
    {
        #region Editor Fields

        [SerializeField] private ClipSelector _selectedAudio;
        [SerializeField] private ClipSelector _submittedAudio;

        #endregion
        
        #region Unity Callbacks

        private void OnEnable()
        {
            ButtonSelectAudio.OnSelected += SelectedCallback;
            ButtonSelectAudio.OnSubmitted += SubmittedCallback;
        }

        private void OnDisable()
        {
            ButtonSelectAudio.OnSelected -= SelectedCallback;
            ButtonSelectAudio.OnSubmitted -= SubmittedCallback;
        }

        #endregion

        #region Methods
        
        private void SelectedCallback()
        {
            _selectedAudio.TryOneShotAudioSource(AudioSource);
        }
        
        private void SubmittedCallback()
        {
            _submittedAudio.TryOneShotAudioSource(AudioSource);
        }
        
        #endregion
    }
}