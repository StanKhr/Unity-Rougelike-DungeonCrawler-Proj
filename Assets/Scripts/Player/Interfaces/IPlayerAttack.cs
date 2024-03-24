using System;
using Miscellaneous.CustomEvents.Contexts;
using Miscellaneous.CustomEvents.Events;
using Player.Inventories.Interfaces;

namespace Player.Interfaces
{
    public interface IPlayerAttack
    {
        #region Events

        ValueEvent<EventContext.MeleeAttackEvent> OnAttackChargeStarted { get; }
        ValueEvent<EventContext.GameObjectEvent> OnSurfaceHit { get; }
        ValueEvent<EventContext.WeaponEvent> OnAttackReleased { get; }
        SimpleEvent OnAttackEnded { get; }

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