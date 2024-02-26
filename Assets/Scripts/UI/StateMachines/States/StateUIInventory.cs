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
            
            SetInventoryCallback(CloseInventory, true);
            SetPauseMenuCallback(CloseInventory, true);
            SetDiscardButtonCallback(DropItem, true);
        }

        public override void Exit()
        {
            var inventoryPresenter = StateMachineUI.InventoryPresenter;
            inventoryPresenter.gameObject.SetActiveSmart(false);
            
            SetInventoryCallback(CloseInventory, false);
            SetPauseMenuCallback(CloseInventory, false);
            SetDiscardButtonCallback(DropItem, false);
        }

        private void CloseInventory()
        {
            StateMachineUI.ToGameplayState();
        }

        private void DropItem()
        {
            var inventoryPresenter = StateMachineUI.InventoryPresenter;
            inventoryPresenter.DropItem();
        }

        #endregion
    }
}