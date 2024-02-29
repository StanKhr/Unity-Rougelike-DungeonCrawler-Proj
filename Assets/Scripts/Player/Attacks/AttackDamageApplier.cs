using System;
using Miscellaneous;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using Player.StateMachines.Interfaces;
using UnityEngine;

namespace Player.Attacks
{
    public class AttackDamageApplier : MonoBehaviour, IAttackDamageApplier
    {
        #region Events

        public event DelegateHolder.FloatEvents OnAttackChargeStarted;
        public event DelegateHolder.FloatEvents OnAttackReleased;
        public event Action OnAttackEnded;

        #endregion
        
        #region Methods

        public void ChargeAttack(IStateMachinePlayer player, IWeapon weapon, float chargeTime)
        {
            OnAttackChargeStarted?.Invoke(chargeTime);
        }

        public void ReleaseAttack(IStateMachinePlayer player, IWeapon weapon, float finalChargeTime)
        {
            OnAttackReleased?.Invoke(finalChargeTime);
        }

        public void EndAttack()
        {
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