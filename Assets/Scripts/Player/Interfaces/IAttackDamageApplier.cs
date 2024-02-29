using System;
using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.StateMachines.Interfaces;

namespace Player.Interfaces
{
    public interface IAttackDamageApplier
    {
        #region Events

        event DelegateHolder.FloatEvents OnAttackChargeStarted;
        event DelegateHolder.FloatEvents OnAttackReleased;
        event Action OnAttackEnded;

        #endregion
        
        #region Methods

        void ChargeAttack(IStateMachinePlayer player, IWeapon weapon, float chargeTime);
        void ReleaseAttack(IStateMachinePlayer player, IWeapon weapon, float finalChargeTime);
        void EndAttack();

        #endregion
    }
}