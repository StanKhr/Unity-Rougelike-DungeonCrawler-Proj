using FSM.Creatures.Interfaces;
using NPCs.Components.Interfaces;

namespace NPCs.FSM.Interfaces
{
    public interface IStateMachineEnemy : IStateMachineHumanoid
    {
        #region Properties

        INavMeshAgentWrapper NavMeshAgentWrapper { get; }
        IPlayerFinder PlayerFinder { get; }

        #endregion

        #region Methods

        #endregion
    }
}