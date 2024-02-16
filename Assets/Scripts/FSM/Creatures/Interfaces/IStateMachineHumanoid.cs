using Abilities.Interfaces;
using Statuses.Interfaces;

namespace FSM.Creatures.Interfaces
{
    public interface IStateMachineHumanoid
    {
        #region Properties

        ILocomotion Locomotion { get; }
        IHealth Health { get; }
        IDamageable Damageable { get; }

        #endregion

        #region Methods

        void Resurrect();
        void ToFreeLookState();
        void ToDeathState();

        #endregion
    }
}