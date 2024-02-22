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

        private IStateMachineUI StateMachineUI { get; }

        #endregion
    }
}