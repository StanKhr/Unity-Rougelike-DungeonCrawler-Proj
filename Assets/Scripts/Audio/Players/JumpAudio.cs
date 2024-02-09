using System;
using Abilities.Interfaces;
using Abilities.Locomotion;
using Audio.ClipSelectors;
using UnityEngine;

namespace Audio.Players
{
    public class JumpAudio : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private LocomotionCharacterController _locomotion;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ClipSelector _clipSelectorJump;
        [SerializeField] private ClipSelector _clipSelectorLanding;

        #endregion

        #region Properties

        private ILocomotion Locomotion => _locomotion;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            Locomotion.OnJumped += JumpCallback;
            Locomotion.OnGroundLanded += GroundLandedCallback;
        }

        private void OnDisable()
        {
            Locomotion.OnJumped -= JumpCallback;
            Locomotion.OnGroundLanded -= GroundLandedCallback;
        }

        #endregion

        #region Methods

        private void JumpCallback()
        {
            _clipSelectorJump.TryOneShotAudioSource(_audioSource);
        }

        private void GroundLandedCallback()
        {
            _clipSelectorLanding.TryOneShotAudioSource(_audioSource);
        }

        #endregion
    }
}