using Cinemachine;
using Player.Cameras.Interfaces;
using Player.Miscellaneous;
using UnityEngine;

namespace Player.Cameras
{
    public class HeadBob : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private FootStepsTracker _footStepsTracker;
        [SerializeField] private CinemachineImpulseSource _cinemachineImpulseSource;

        #endregion

        #region Properties

        private IFootStepsTracker FootStepsTracker => _footStepsTracker;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            FootStepsTracker.OnStepMade += StepMadeCallback;
        }

        private void OnDestroy()
        {
            FootStepsTracker.OnStepMade -= StepMadeCallback;
        }

        #endregion

        #region Methods


        private void StepMadeCallback()
        {
            _cinemachineImpulseSource.GenerateImpulse();
        }

        #endregion
    }
}