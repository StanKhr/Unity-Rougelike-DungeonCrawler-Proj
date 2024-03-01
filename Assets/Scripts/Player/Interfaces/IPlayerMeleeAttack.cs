using System;
using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.StateMachines.Interfaces;

namespace Player.Interfaces
{
    public interface IPlayerMeleeAttack
    {
        #region Events

        event DelegateHolder.WeaponEvents OnAttackChargeStarted;
        event DelegateHolder.WeaponEvents OnAttackReleased;
        event Action OnAttackEnded; 

        #endregion

        #region Properties

        bool ChargingAttack { get; }
        float ChargePercent { get; }

        #endregion
        
        #region Methods

        void ChargeAttack(IWeapon weapon);
        void Tick(float deltaTime);
        void ReleaseAttack();
        void InterruptAttack();

        #endregion
    }
}