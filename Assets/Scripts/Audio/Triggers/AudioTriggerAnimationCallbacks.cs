using System;
using Audio.ClipSelectors;
using Audio.Interfaces;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerAnimationCallbacks : AudioTrigger
    {
        #region Types

        [Serializable]
        private struct SelectorWithVolume
        {
            [SerializeField] private ClipSelector _clipSelector;
            [SerializeField, Range(0f, 1f)] private float _volume;

            private IClipSelector ClipSelector => _clipSelector;

            public void Trigger(AudioSource audioSource)
            {
                ClipSelector?.TryOneShotOnAudioSource(audioSource, _volume);
            }
        }

        #endregion
        
        #region Editor Fields

        [SerializeField] private SelectorWithVolume _footSteps;
        [SerializeField] private SelectorWithVolume _attack;

        #endregion

        #region Methods

        public void AnimCallbackPlayAttack()
        {
            _attack.Trigger(AudioSource);
        }

        public void AnimCallbackPlayFootStep()
        {
            _footSteps.Trigger(AudioSource);
        }

        #endregion
    }
}