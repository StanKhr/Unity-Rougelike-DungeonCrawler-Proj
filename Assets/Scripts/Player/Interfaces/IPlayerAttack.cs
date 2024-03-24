using System;
using Miscellaneous;
using Player.Inventories.Interfaces;

namespace Player.Interfaces
{
    public interface IPlayerAttack
    {
        #region Events

        // GameEvents.Event<GameEvents.MeleeAttackEvent>
        event Action<GameEvents.MeleeAttackEvent> OnAttackChargeStarted;
        event DelegateHolder.WeaponEvents OnAttackReleased;
        event DelegateHolder.GameObjectEvents OnSurfaceHit;
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