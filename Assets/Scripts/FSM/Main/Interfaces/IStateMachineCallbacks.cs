namespace FSM.Main.Interfaces
{
    public interface IStateMachineCallbacks
    {
        #region Methods

        void CallStateChanged(StateMachine stateMachine, IState newState);

        #endregion
    }
}