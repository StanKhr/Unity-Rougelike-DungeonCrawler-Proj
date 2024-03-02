using System;
using Miscellaneous;
using Player.Inventories.Interfaces;

namespace Player.Interfaces
{
    public interface IPlayerAttack
    {
        #region Events

        event DelegateHolder.MeleeAttackDataEvents OnAttackChargeStarted;
        event DelegateHolder.WeaponEvents OnAttackReleased;
        event DelegateHolder.MeleeAttackDataEvents OnAttackApplied;
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