﻿using Audio.ClipSelectors;
using Audio.Interfaces;
using UI.Utility;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerUiEvents : AudioTrigger
    {
        #region Editor Fields

        [SerializeField] private ClipSelectorMono _selectedAudio;
        [SerializeField] private ClipSelectorMono _submittedAudio;

        #endregion

        #region Properties

        private IClipSelector ClipSelectorSelected => _selectedAudio;
        private IClipSelector ClipSelectorSubmitted => _submittedAudio;

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
            ClipSelectorSelected.TryOneShotAudioSource(AudioSource);
        }
        
        private void SubmittedCallback()
        {
            ClipSelectorSubmitted.TryOneShotAudioSource(AudioSource);
        }
        
        #endregion
    }
}