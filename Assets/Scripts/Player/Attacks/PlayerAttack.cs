﻿using System;
using System.Collections.Generic;
using Miscellaneous;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using Statuses.Datas;
using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;

namespace Player.Attacks
{
    public class PlayerAttack : MonoBehaviour, IPlayerAttack
    {
        #region Constant

        private const float CritMinimumChargePercent = 0.5f;
        private const float MinChargeTime = 0.1f;
        private const float MinAttackDamage = 1.0f;

        #endregion

        #region Events

        public event DelegateHolder.MeleeAttackDataEvents OnAttackChargeStarted;
        public event DelegateHolder.WeaponEvents OnAttackReleased;
        public event DelegateHolder.MeleeAttackDataEvents OnAttackApplied;
        public event DelegateHolder.GameObjectEvents OnSurfaceHit;
        public event Action OnAttackEnded;

        #endregion

        #region Editor Fields

        [SerializeField] private Health _ownerHealth;
        [SerializeField] private SphereCollider _attackCollider;

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
        private readonly List<Collider> _affectedTargets = new();

        #endregion

        #region Properties

        private IDamageable OwnerDamageable => _ownerHealth;

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

        private void Start()
        {
            _attackCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_affectedTargets.Contains(other))
            {
                return;
            }

            _affectedTargets.Add(other);

            if (other.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                TryApplyDamage(damageable);
            }

            OnSurfaceHit?.Invoke(other.gameObject);
        }

        private void TryApplyDamage(IDamageable damageable)
        {
            if (damageable == OwnerDamageable)
            {
                return;
            }

            var damage = new Damage()
            {
                Value = _calculatedDamage,
                DamageType = UsedWeapon.DamageType,
                Source = _ownerHealth.gameObject
            };

            if (!damageable.TryApplyDamage(damage))
            {
                return;
            }

            var attackData = new MeleeAttackData(UsedWeapon, 0f, _applyCriticalDamage);
            OnAttackApplied?.Invoke(attackData);
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

            var halvedBounds = UsedWeapon.CritPercentBounds * 0.5f;
            var critMinPercent = CritMinimumChargePercent + halvedBounds;
            var critMaxPercent = 1 - halvedBounds;
            
            _critChargePercent = Randomizer.RangeFloat(critMinPercent, critMaxPercent);
            var attackData = new MeleeAttackData(UsedWeapon, _critChargePercent, false);

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

            var chargePercent = ChargeTimer / _maxChargeTimeSeconds;
            _applyCriticalDamage =CheckCritCharge(chargePercent, 
                _critChargePercent, UsedWeapon.CritPercentBounds);
            _calculatedDamage = CalculateDamageValue(UsedWeapon, ChargeTimer, _applyCriticalDamage);

            OnAttackReleased?.Invoke(UsedWeapon);

            _affectedTargets.Clear();
            _attackCollider.enabled = true;
        }

        public void InterruptAttack()
        {
            ChargingAttack = false;
            _attackDuration = 0f;

            OnAttackEnded?.Invoke();

            _attackCollider.enabled = false;
        }

        private static bool CheckCritCharge(float chargeTimePercent, float critChargePercent, float critPercentBounds)
        {
            return Math.Abs(chargeTimePercent - critChargePercent) <= critPercentBounds * 0.5F;
        }

        private static float CalculateDamageValue(IWeapon weapon, float chargeTime, bool critApplied)
        {
            var chargeTimeSeconds = weapon.CalculateChargeTimeSeconds();
            float totalDamage;

            if (critApplied)
            {
                totalDamage = weapon.DamageValue * weapon.CritDamageMultiplier;
            }
            else
            {
                totalDamage = weapon.DamageValue * (chargeTime / chargeTimeSeconds);
            }

            return Mathf.Max(totalDamage, MinAttackDamage);
        }

        #endregion
    }
}