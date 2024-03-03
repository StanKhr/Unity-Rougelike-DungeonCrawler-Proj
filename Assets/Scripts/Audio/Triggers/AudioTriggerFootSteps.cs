using Audio.ClipSelectors;
using Audio.ClipSelectors.Mono;
using Audio.ClipSelectors.Scriptables;
using Audio.Interfaces;
using Player.Cameras.Interfaces;
using Player.Miscellaneous;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerFootSteps : AudioTrigger
    {
        #region Editor Fields

        [SerializeField] private FootStepsTracker _footStepsTracker;
        [SerializeField] private ClipSelectorScriptable _clipSelector;

        #endregion

        #region Properties

        private IFootStepsTracker FootStepsTracker => _footStepsTracker;
        private IClipSelector ClipSelector => _clipSelector;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            FootStepsTracker.OnStepMade += StepMadeCallback;
        }

        private void OnDisable()
        {
            FootStepsTracker.OnStepMade -= StepMadeCallback;
        }

        #endregion

        #region Methods

        private void StepMadeCallback()
        {
            ClipSelector.TryOneShotAudioSource(AudioSource);
        }

        #endregion
    }
}