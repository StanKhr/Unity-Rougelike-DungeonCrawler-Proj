using Audio.ClipSelectors;
using Audio.Interfaces;
using Miscellaneous;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerDamageFeedback : DamageFeedback
    {
        #region Editor Fields

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ClipSelectorMono _damagedClipSelector;
        [SerializeField] private ClipSelectorMono _diedClipSelector;

        #endregion

        #region Properties

        protected override bool ObserveDeath => true;
        private IClipSelector DamagedClipSelector => _damagedClipSelector;
        private IClipSelector DiedClipSelector => _diedClipSelector;

        #endregion

        #region Methods
        
        protected override void DamagedCallback(float context)
        {
            DamagedClipSelector.TryOneShotAudioSource(_audioSource);
        }

        protected override void DiedCallback()
        {
            DiedClipSelector.TryOneShotAudioSource(_audioSource);
        }

        #endregion
    }
}
