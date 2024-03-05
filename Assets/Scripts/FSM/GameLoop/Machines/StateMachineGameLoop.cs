using FSM.GameLoop.Interfaces;
using FSM.Main;

namespace FSM.GameLoop.Machines
{
    public class StateMachineGameLoop : StateMachine, IStateMachineGameLoop
    {
        #region Unity Callbacks

        protected override void Start()
        {
            base.Start();
            ToMainMenuState();
        }

        #endregion
        
        #region Methods
        
        public void ToMainMenuState()
        {
            
        }

        #endregion
    }
}
