using FSM.Main;
using NPCs.FSM.Interfaces;

namespace NPCs.FSM.States
{
    public abstract class StateEnemy : State
    {
        #region Constructors

        protected StateEnemy(IStateMachineEnemy stateMachineEnemy)
        {
            StateMachineEnemy = stateMachineEnemy;
        }

        #endregion

        #region Properties

        protected IStateMachineEnemy StateMachineEnemy { get; }

        #endregion
    }
}