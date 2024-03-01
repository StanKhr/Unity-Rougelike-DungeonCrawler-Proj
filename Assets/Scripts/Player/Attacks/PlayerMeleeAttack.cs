﻿using System;
using Miscellaneous;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.Attacks
{
    public class PlayerMeleeAttack : MonoBehaviour, IPlayerMeleeAttack
    {
        #region Constant
        
        private const float MinChargeTime = 0.1f;

        #endregion
        
        #region Events
        
        public event DelegateHolder.WeaponEvents OnAttackChargingStarted;
        public event DelegateHolder.WeaponEvents OnAttackReleased;
        public event Action OnAttackEnded;
        
        #endregion

        #region Editor Fields

        [SerializeField] private Transform _attackTransformDummy;
        [SerializeField] private float _attackRadius;

        #endregion

        #region Fields

        private IWeapon _usedWeapon;
        private float _maxChargeTimeSeconds;
        private float _chargeTimer;
        private bool _chargingAttack;
        private float _attackDuration;

        #endregion

        #region Properties

        private IWeapon UsedWeapon
        {
            get => _usedWeapon;
            set
            {
                _usedWeapon = value;
                if (UsedWeapon == null)
                {
                    return;
                }
                
                _maxChargeTimeSeconds = UsedWeapon.CalculateChargeTimeSeconds();
                _attackDuration = UsedWeapon.AttackDuration;
                ChargeTimer = 0f;
            }
        }
        public bool ChargingAttack
        {
            get => _chargingAttack;
            private set
            {
                if (ChargingAttack == value)
                {
                    return;
                }
                
                _chargingAttack = value;
            }
        }
        private float ChargeTimer
        {
            get => _chargeTimer;
            set => _chargeTimer = Mathf.Clamp(value, 0, _maxChargeTimeSeconds);
        }

        #endregion

        #region Unity Callbacks

        private void OnDrawGizmos()
        {
            if (!_attackTransformDummy)
            {
                return;
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackTransformDummy.position, _attackRadius);
        }

        #endregion
        
        #region Methods

        public void ChargeAttack(IWeapon weapon)
        {
            if (ChargingAttack)
            {
                return;
            }

            UsedWeapon = weapon;
            
            ChargingAttack = true;
            
            OnAttackChargingStarted?.Invoke(UsedWeapon);
        }

        public void Tick(float deltaTime)
        {
            if (ChargingAttack)
            {
                ChargeTimer += deltaTime;
                return;
            }

            if (_attackDuration > 0f)
            {
                _attackDuration -= deltaTime;
                // try apply damage
                return;
            }
            
            InterruptAttack();
        }

        public void ReleaseAttack()
        {
            if (!ChargingAttack)
            {
                return;
            }

            if (ChargeTimer < MinChargeTime)
            {
                return;
            }
            
            ChargingAttack = false;
            
            OnAttackReleased?.Invoke(UsedWeapon);
        }

        public void InterruptAttack()
        {
            ChargingAttack = false;
            _attackDuration = 0f;
            
            OnAttackEnded?.Invoke();
        }

        private static float CalculateDamageValue(IWeapon weapon, float chargeTime)
        {
            var chargeTimeSeconds = weapon.CalculateChargeTimeSeconds();
            return weapon.DamageValue * (chargeTime / chargeTimeSeconds);
        }

        #endregion
    }
}