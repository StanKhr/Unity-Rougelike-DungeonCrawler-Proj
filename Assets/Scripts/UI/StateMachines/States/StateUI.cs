using FSM.Main;
using UI.StateMachines.Interfaces;

namespace UI.StateMachines.States
{
    public abstract class StateUI : State
    {
        #region Constructors

        protected StateUI(IStateMachineUI stateMachineUI)
        {
            StateMachineUI = stateMachineUI;
        }

        #endregion

        #region Properties

        protected IStateMachineUI StateMachineUI { get; }
        public override bool TickEnabled => false;

        #endregion

        #region Methods

        public override void Tick(float deltaTime)
        {
            
        }

        #endregion
    }
}