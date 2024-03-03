using Audio.ClipSelectors;
using Audio.Interfaces;
using UnityEngine;

namespace Statuses.Feedbacks.Damage
{
    public class DamageFeedbackAudioTrigger : DamageFeedback
    {
        #region Editor Fields

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ClipSelectorScriptable _damagedClipSelector;
        [SerializeField] private ClipSelectorScriptable _diedClipSelector;
        [SerializeField] private bool _observeDeath = true;

        #endregion

        #region Properties

        protected override bool ObserveDeath => _observeDeath;
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
