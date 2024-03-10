using FSM.GameLoop.Interfaces;
using FSM.Main;

namespace FSM.GameLoop.States
{
    public abstract class StateGameLoop : State
    {
        #region Constructors

        protected StateGameLoop(IStateMachineGameLoop stateMachineGameLoop)
        {
            StateMachine = stateMachineGameLoop;
        }

        #endregion

        #region Properties

        protected IStateMachineGameLoop StateMachine { get; }
        public override bool TickEnabled => false;

        #endregion

        #region Methods

        public override void Tick(float deltaTime)
        {
            
        }

        #endregion
    }
}