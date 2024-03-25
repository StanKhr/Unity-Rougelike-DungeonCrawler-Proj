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
            EnableCursor(false);
            SetInventoryCallback(OpenInventory, true);
            SetPauseMenuCallback(PauseGame, true);
        }

        public override void Exit()
        {
            EnableGameplayInputs(false);
            EnableCursor(true);
            SetInventoryCallback(OpenInventory, false);
            SetPauseMenuCallback(PauseGame, false);
        }

        private void OpenInventory()
        {
            StateMachineUI.ToInventoryState();
        }

        private void PauseGame()
        {
            StateMachineUI.ToPauseMenuState();
        }

        #endregion
    }
}