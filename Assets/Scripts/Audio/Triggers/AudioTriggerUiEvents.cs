using Audio.ClipSelectors;
using Audio.Interfaces;
using Miscellaneous;
using UI.Utility;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerUiEvents : AudioTrigger
    {
        #region Editor Fields
        
        [SerializeField] private ClipSelector _selectedAudio;
        [SerializeField] private ClipSelector _submittedAudio;
        [SerializeField] private ClipSelector _windowOpened;
        [SerializeField] private ClipSelector _windowClosed;

        #endregion

        #region Properties

        private IClipSelector ClipSelectorSelected => _selectedAudio;
        private IClipSelector ClipSelectorSubmitted => _submittedAudio;

        #endregion
        
        #region Unity Callbacks

        private void OnEnable()
        {
            ButtonSelectionEvents.OnSelected.AddListener(SelectedCallback);
            ButtonSelectionEvents.OnSubmitted.AddListener(SubmittedCallback);
        }

        private void OnDisable()
        {
            ButtonSelectionEvents.OnSelected.AddListener(SelectedCallback);
            ButtonSelectionEvents.OnSubmitted.AddListener(SubmittedCallback);
        }

        #endregion

        #region Methods
        
        private void SelectedCallback(EventContext.GameObjectEvent context)
        {
            ClipSelectorSelected?.TryOneShotOnAudioSource(AudioSource);
        }
        
        private void SubmittedCallback(EventContext.GameObjectEvent context)
        {
            ClipSelectorSubmitted?.TryOneShotOnAudioSource(AudioSource);
        }
        
        #endregion
    }
}