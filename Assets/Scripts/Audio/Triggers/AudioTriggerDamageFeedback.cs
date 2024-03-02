using Audio.ClipSelectors;
using Miscellaneous;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerDamageFeedback : DamageFeedback
    {
        #region Editor Fields

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ClipSelector _damagedClipSelector;
        [SerializeField] private ClipSelector _diedClipSelector;

        #endregion

        #region Properties

        protected override bool ObserveDeath => true;

        #endregion

        #region Methods
        
        protected override void DamagedCallback(float context)
        {
            _damagedClipSelector.TryOneShotAudioSource(_audioSource);
        }

        protected override void DiedCallback()
        {
            _diedClipSelector.TryOneShotAudioSource(_audioSource);
        }

        #endregion
    }
}
