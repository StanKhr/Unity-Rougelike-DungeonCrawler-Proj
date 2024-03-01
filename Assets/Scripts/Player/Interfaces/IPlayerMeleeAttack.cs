using System;
using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.StateMachines.Interfaces;

namespace Player.Interfaces
{
    public interface IPlayerMeleeAttack
    {
        #region Events

        event DelegateHolder.WeaponEvents OnAttackChargingStarted;
        event DelegateHolder.WeaponEvents OnAttackReleased;
        event Action OnAttackInterrupted; 

        #endregion

        #region Properties

        bool ChargingAttack { get; }

        #endregion
        
        #region Methods

        void ChargeAttack(IWeapon weapon);
        void TickCharge(float deltaTime);
        void ReleaseAttack();
        void InterruptAttack();

        #endregion
    }
}