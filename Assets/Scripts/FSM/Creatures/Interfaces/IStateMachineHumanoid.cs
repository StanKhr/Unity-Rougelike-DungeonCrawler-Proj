using Abilities.Interfaces;

namespace FSM.Creatures.Interfaces
{
    public interface IStateMachineHumanoid
    {
        #region Properties

        ILocomotion Locomotion { get; }

        #endregion
    }
}