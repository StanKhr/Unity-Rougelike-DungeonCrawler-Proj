using Miscellaneous;
using UI.StateMachines.Interfaces;

namespace UI.StateMachines.States
{
    public class StateUIGameplay : StateUI
    {
        #region Constructors
        
        public StateUIGameplay(IStateMachineUI stateMachineUI) : base(stateMachineUI)
        {
            
        }

        #endregion
        
        #region Methods
        
        public override void Enter()
        {
            LogWriter.DevelopmentLog($"Entered gameplay state");
        }

        public override void Exit()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            
        }

        #endregion
    }
}