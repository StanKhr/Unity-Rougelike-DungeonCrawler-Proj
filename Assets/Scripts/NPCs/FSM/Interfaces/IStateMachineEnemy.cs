using FSM.Creatures.Interfaces;
using NPCs.Interfaces;

namespace NPCs.FSM.Interfaces
{
    public interface IStateMachineEnemy : IStateMachineHumanoid
    {
        #region Properties

        INavMeshAgentWrapper NavMeshAgentWrapper { get; }
        IPlayerFinder PlayerFinder { get; }
        IEnemyAnimations EnemyAnimations { get; }
        IEnemyAttack EnemyAttack { get; }

        #endregion

        #region Methods

        void ToChasePlayerState();
        void ToAttackState();

        #endregion
    }
}