using System;
using Audio.ClipSelectors;
using Player.Cameras;
using Player.Cameras.Interfaces;
using UnityEngine;

namespace Audio
{
    public class FootStepsAudio : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private CameraWrapper _cameraWrapper;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ClipSelector _clipSelector;

        #endregion

        #region Properties

        private ICameraWrapper CameraWrapper => _cameraWrapper;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            CameraWrapper.OnFootStepped += FootSteppedCallback;
        }

        private void OnDisable()
        {
            CameraWrapper.OnFootStepped -= FootSteppedCallback;
        }

        #endregion

        #region Methods

        private void FootSteppedCallback()
        {
            _clipSelector.TryOneShotAudioSource(_audioSource);
        }

        #endregion
    }
}