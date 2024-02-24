using Audio.ClipSelectors;
using Miscellaneous;
using UI.Presenters;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerDamageFeedback : DamageFeedback
    {
        #region Editor Fields

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ClipSelectorRandom _clipSelector;

        #endregion

        #region Methods
        
        protected override void DamagedCallback(float context)
        {
            _clipSelector.TryOneShotAudioSource(_audioSource);
        }

        #endregion
    }
}
