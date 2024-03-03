using System;
using Player.Attacks;
using Player.Interfaces;
using Player.Inventories.Interfaces;
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
            PlayerAttack.OnAttackChargeStarted += AttackChargeStartedCallback;
            PlayerAttack.OnAttackReleased += AttackReleasedCallback;
        }

        private void OnDisable()
        {
            PlayerAttack.OnAttackChargeStarted -= AttackChargeStartedCallback;
            PlayerAttack.OnAttackReleased -= AttackReleasedCallback;
        }

        #endregion

        #region Methods

        private void AttackReleasedCallback(IWeapon context)
        {
            var clipSelector = context.ClipSelectorAttackRelease;
            clipSelector.TryPlayOneShot(AudioSource);
        }

        private void AttackChargeStartedCallback(MeleeAttackData context)
        {
            var clipSelector = context.Weapon.ClipSelectorAttackCharge;
            clipSelector.TryPlayOneShot(AudioSource);
        }

        #endregion
    }
}