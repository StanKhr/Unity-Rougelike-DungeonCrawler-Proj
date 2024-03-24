using Audio.ClipSelectors;
using Audio.Interfaces;
using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;

namespace Statuses.Feedbacks.Damage
{
    public class DamageFeedbackAudioTrigger : DamageFeedback
    {
        #region Editor Fields

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ClipSelector _damagedClipSelector;
        [SerializeField] private ClipSelector _diedClipSelector;
        [SerializeField] private bool _observeDeath = true;

        #endregion

        #region Properties

        protected override bool ObserveDeath => _observeDeath;
        private IClipSelector DamagedClipSelector => _damagedClipSelector;
        private IClipSelector DiedClipSelector => _diedClipSelector;

        #endregion

        #region Methods
        
        protected override void DamagedCallback(Events.FloatEvent context)
        {
            DamagedClipSelector.TryOneShotOnAudioSource(_audioSource);
        }

        protected override void DiedCallback()
        {
            DiedClipSelector.TryOneShotOnAudioSource(_audioSource);
        }

        #endregion
    }
}
