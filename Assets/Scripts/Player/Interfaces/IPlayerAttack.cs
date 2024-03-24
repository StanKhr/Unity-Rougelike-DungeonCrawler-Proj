using System;
using Miscellaneous.CustomEvents.Contexts;
using Miscellaneous.CustomEvents.Events;
using Miscellaneous.CustomEvents.Interfaces;
using Player.Inventories.Interfaces;

namespace Player.Interfaces
{
    public interface IPlayerAttack
    {
        #region Events

        IValueEvent<EventContext.MeleeAttackEvent> OnAttackChargeStarted { get; }
        IValueEvent<EventContext.GameObjectEvent> OnSurfaceHit { get; }
        IValueEvent<EventContext.WeaponEvent> OnAttackReleased { get; }
        IEvent OnAttackEnded { get; }

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