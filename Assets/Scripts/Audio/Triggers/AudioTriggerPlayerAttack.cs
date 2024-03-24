using Miscellaneous.CustomEvents.Contexts;
using Player.Attacks;
using Player.Interfaces;
using UnityEngine;

namespace Audio.Triggers
{
    public class AudioTriggerPlayerAttack : AudioTrigger
    {
        #region Editor Fields

        [SerializeField] private PlayerAttack _playerAttack;

        #endregion

        #region Properties

        private IPlayerAttack PlayerAttack => _playerAttack;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            PlayerAttack.OnAttackChargeStarted.AddCallback(AttackChargeStartedCallback);
            PlayerAttack.OnAttackReleased.AddCallback(AttackReleasedCallback);
        }

        private void OnDisable()
        {
            PlayerAttack.OnAttackChargeStarted.RemoveCallback(AttackChargeStartedCallback);
            PlayerAttack.OnAttackReleased.RemoveCallback(AttackReleasedCallback);
        }

        #endregion

        #region Methods

        private void AttackReleasedCallback(EventContext.WeaponEvent context)
        {
            var clipSelector = context.Weapon.ClipSelectorAttackRelease;
            clipSelector.TryOneShotOnAudioSource(AudioSource);
        }

        private void AttackChargeStartedCallback(EventContext.MeleeAttackEvent context)
        {
            var clipSelector = context.Weapon.ClipSelectorAttackCharge;
            clipSelector.TryOneShotOnAudioSource(AudioSource);
        }

        #endregion
    }
}