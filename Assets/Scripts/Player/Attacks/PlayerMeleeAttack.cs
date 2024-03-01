﻿using System;
using Miscellaneous;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player.Attacks
{
    public class PlayerMeleeAttack : MonoBehaviour, IPlayerMeleeAttack
    {
        #region Constant
        
        private const float MinChargeTime = 0.1f;
        private const float CritMinPercent = 0.6f;
        private const float CritMaxPercent = 0.9f;
        private const float CritPercentageBounds = 0.05f;
        private const float CritDamagePercent = 1.2f;

        #endregion
        
        #region Events
        
        public event DelegateHolder.MeleeAttackDataEvents OnAttackChargeStarted;
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
        private float _critChargePercent;
        private bool _applyCriticalDamage;
        private float _calculatedDamage;

        #endregion

        #region Properties
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
        public float ChargePercent => ChargeTimer / _maxChargeTimeSeconds;
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

            _critChargePercent = Random.Range(CritMinPercent, CritMaxPercent);
            var attackData = new MeleeAttackData(UsedWeapon, _critChargePercent);
            
            OnAttackChargeStarted?.Invoke(attackData);
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
            _applyCriticalDamage = CheckCritCharge(ChargeTimer, _critChargePercent);
            _calculatedDamage = CalculateDamageValue(UsedWeapon, ChargeTimer, _applyCriticalDamage);
            
            OnAttackReleased?.Invoke(UsedWeapon);
        }

        public void InterruptAttack()
        {
            ChargingAttack = false;
            _attackDuration = 0f;
            
            OnAttackEnded?.Invoke();
        }

        private static bool CheckCritCharge(float chargeTime, float critChargePercent)
        {
            return Math.Abs(chargeTime - critChargePercent) < CritPercentageBounds;
        }

        private static float CalculateDamageValue(IWeapon weapon, float chargeTime, bool critApplied)
        {
            var chargeTimeSeconds = weapon.CalculateChargeTimeSeconds();
            if (critApplied)
            {
                return weapon.DamageValue * CritDamagePercent;
            }
            
            return weapon.DamageValue * (chargeTime / chargeTimeSeconds);
        }

        #endregion
    }
}