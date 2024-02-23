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
            var inputProvider = StateMachineUI.InputProvider;
            
            inputProvider.MapWrapperCamera.EnableMap(true);
            inputProvider.MapWrapperMovement.EnableMap(true);
            
        }

        public override void Exit()
        {
            var inputProvider = StateMachineUI.InputProvider;
            
            inputProvider.MapWrapperCamera.EnableMap(false);
            inputProvider.MapWrapperMovement.EnableMap(false);
        }

        #endregion
    }
}