using Miscellaneous;
using Player.Inventories.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;

namespace Player.Interfaces
{
    public interface IPlayerAttack
    {
        #region Events

        IContextEvent<EventContext.MeleeAttackEvent> OnAttackChargeStarted { get; }
        IContextEvent<EventContext.GameObjectEvent> OnSurfaceHit { get; }
        IContextEvent<EventContext.WeaponEvent> OnAttackReleased { get; }
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