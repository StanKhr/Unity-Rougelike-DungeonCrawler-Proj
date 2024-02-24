using UI.StateMachines.Interfaces;
using UI.Utility;

namespace UI.StateMachines.States
{
    public class StateUIInventory : StateUI
    {
        #region Constructors

        public StateUIInventory(IStateMachineUI stateMachineUI) : base(stateMachineUI)
        {
        }

        #endregion

        #region Methods

        public override void Enter()
        {
            var inventoryPresenter = StateMachineUI.InventoryPresenter;
            inventoryPresenter.gameObject.SetActiveSmart(true);
            
            SetInventoryCallback(InventoryInputCallback, true);
            SetPauseMenuCallback(InventoryInputCallback, true);
        }

        public override void Exit()
        {
            var inventoryPresenter = StateMachineUI.InventoryPresenter;
            inventoryPresenter.gameObject.SetActiveSmart(false);
            
            SetInventoryCallback(InventoryInputCallback, false);
            SetPauseMenuCallback(InventoryInputCallback, false);
        }

        private void InventoryInputCallback()
        {
            StateMachineUI.ToGameplayState();
        }

        #endregion
    }
}