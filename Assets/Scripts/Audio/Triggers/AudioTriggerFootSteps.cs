using Audio.ClipSelectors;
using Player.Cameras;
using Player.Cameras.Interfaces;
using Player.Miscellaneous;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerFootSteps : AudioTrigger
    {
        #region Editor Fields

        [SerializeField] private FootStepsTracker _footStepsTracker;
        [SerializeField] private ClipSelector _clipSelector;

        #endregion

        #region Properties

        private IFootStepsTracker FootStepsTracker => _footStepsTracker;

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
            _clipSelector.TryOneShotAudioSource(AudioSource);
        }

        #endregion
    }
}