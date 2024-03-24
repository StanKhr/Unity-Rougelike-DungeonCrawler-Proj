using System;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using Player.Inventories.Interfaces;

namespace Player.Interfaces
{
    public interface IPlayerAttack
    {
        #region Events

        IContextEvent<Events.MeleeAttackEvent> OnAttackChargeStarted { get; }
        IContextEvent<Events.GameObjectEvent> OnSurfaceHit { get; }
        IContextEvent<Events.WeaponEvent> OnAttackReleased { get; }
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