using Abilities.Interfaces;
using Abilities.Locomotion;
using Audio.ClipSelectors;
using Audio.Interfaces;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerJump : AudioTrigger
    {
        #region Editor Fields

        [SerializeField] private LocomotionCharacterController _locomotion;
        [SerializeField] private ClipSelectorMono _clipSelectorJump;
        [SerializeField] private ClipSelectorMono _clipSelectorLanding;

        #endregion

        #region Properties

        private IClipSelector ClipSelectorJump => _clipSelectorJump;
        private IClipSelector ClipSelectorLanding => _clipSelectorLanding;
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
            ClipSelectorJump.TryOneShotAudioSource(AudioSource);
        }

        private void GroundLandedCallback()
        {
            ClipSelectorLanding.TryOneShotAudioSource(AudioSource);
        }

        #endregion
    }
}