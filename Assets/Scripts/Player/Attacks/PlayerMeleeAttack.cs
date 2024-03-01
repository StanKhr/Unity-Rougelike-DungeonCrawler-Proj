using System;
using Miscellaneous;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using Player.StateMachines.Interfaces;
using UnityEngine;

namespace Player.Attacks
{
    public class PlayerMeleeAttack : MonoBehaviour, IPlayerMeleeAttack
    {
        #region Constant
        
        private const float MinChargeTime = 0.1f;
        private const float ReleaseAnimationTimeSeconds = 0.5f;

        #endregion
        
        #region Events
        
        public event DelegateHolder.WeaponEvents OnAttackChargingStarted;
        public event DelegateHolder.WeaponEvents OnAttackReleased;
        public event Action OnAttackInterrupted;
        
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

            _usedWeapon = weapon;
            _maxChargeTimeSeconds = _usedWeapon.CalculateChargeTimeSeconds();
            ChargeTimer = 0f;
            
            ChargingAttack = true;
            
            OnAttackChargingStarted?.Invoke(_usedWeapon);
        }

        public void TickCharge(float deltaTime)
        {
            if (!ChargingAttack)
            {
                return;
            }
            
            ChargeTimer += deltaTime;
        }

        public void ReleaseAttack()
        {
            if (!ChargingAttack)
            {
                return;
            }
            
            ChargingAttack = false;
                
            OnAttackReleased?.Invoke(_usedWeapon);
        }

        public void InterruptAttack()
        {
            if (!ChargingAttack)
            {
                return;
            }

            ChargingAttack = false;
            
            OnAttackInterrupted?.Invoke();
        }

        private static float CalculateDamageValue(IWeapon weapon, float chargeTime)
        {
            var chargeTimeSeconds = weapon.CalculateChargeTimeSeconds();
            return weapon.DamageValue * (chargeTime / chargeTimeSeconds);
        }

        #endregion
    }
}