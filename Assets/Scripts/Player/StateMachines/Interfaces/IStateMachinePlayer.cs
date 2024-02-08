using Abilities.Interfaces;
using FSM.Creatures.Interfaces;
using Player.Inputs.Interfaces;

namespace Player.StateMachines.Interfaces
{
    public interface IStateMachinePlayer : IStateMachineHumanoid
    {
        #region Properties

        IInputProvider InputProvider { get; }

        #endregion
    }
}