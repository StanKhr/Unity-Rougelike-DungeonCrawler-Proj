using Audio.ClipSelectors;
using Audio.Interfaces;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerFootStepsAnimation : AudioTrigger
    {
        #region Editor Fields

        [SerializeField, Range(0f, 1f)] private float _volume = 0.6f;
        [SerializeField] private ClipSelector _clipSelector;

        #endregion

        #region Properties
        
        private IClipSelector ClipSelector => _clipSelector;

        #endregion

        #region Methods

        public void PlayFootStep()
        {
            ClipSelector.TryOneShotOnAudioSource(AudioSource, _volume);
        }

        #endregion
    }
}