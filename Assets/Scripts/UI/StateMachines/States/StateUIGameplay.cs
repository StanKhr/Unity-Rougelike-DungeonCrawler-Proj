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
            EnableGameplayInputs(true);
            SetInventoryCallback(InventoryInputCallback, true);
        }

        public override void Exit()
        {
            EnableGameplayInputs(false);
            SetInventoryCallback(InventoryInputCallback, false);
        }

        private void InventoryInputCallback()
        {
            StateMachineUI.ToInventoryState();
        }

        #endregion
    }
}