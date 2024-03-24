using Miscellaneous;
using Player.Attacks;
using Player.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
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
            PlayerAttack.OnAttackChargeStarted.AddListener(AttackChargeStartedCallback);
            PlayerAttack.OnAttackReleased.AddListener(AttackReleasedCallback);
        }

        private void OnDisable()
        {
            PlayerAttack.OnAttackChargeStarted.RemoveListener(AttackChargeStartedCallback);
            PlayerAttack.OnAttackReleased.RemoveListener(AttackReleasedCallback);
        }

        #endregion

        #region Methods

        private void AttackReleasedCallback(Events.WeaponEvent context)
        {
            var clipSelector = context.Weapon.ClipSelectorAttackRelease;
            clipSelector.TryOneShotOnAudioSource(AudioSource);
        }

        private void AttackChargeStartedCallback(Events.MeleeAttackEvent context)
        {
            var clipSelector = context.Weapon.ClipSelectorAttackCharge;
            clipSelector.TryOneShotOnAudioSource(AudioSource);
        }

        #endregion
    }
}