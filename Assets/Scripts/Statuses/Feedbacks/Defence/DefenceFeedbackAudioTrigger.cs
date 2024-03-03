using System;
using Audio.ClipSelectors.Mono;
using Audio.ClipSelectors.Scriptables;
using Audio.Interfaces;
using Audio.Triggers;
using UnityEngine;

namespace Statuses.Feedbacks.Defence
{
    public class DefenceFeedbackAudioTrigger : DefenceFeedback
    {
        #region Editor Fields

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ClipSelectorScriptable _clipSelectorMono;

        #endregion

        #region Properties

        private IClipSelector ClipSelector => _clipSelectorMono;

        #endregion

        #region Unity Callbacks

        protected override void DamageAbsorbedCallback()
        {
            ClipSelector.TryOneShotAudioSource(_audioSource);
        }

        #endregion
    }
}