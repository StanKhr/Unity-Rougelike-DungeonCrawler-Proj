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
            inventoryPresenter.ActivateObjectSelf(true);
            
            SetInventoryCallback(InventoryInputCallback, true);
        }

        public override void Exit()
        {
            var inventoryPresenter = StateMachineUI.InventoryPresenter;
            inventoryPresenter.ActivateObjectSelf(false);
            
            SetInventoryCallback(InventoryInputCallback, false);
        }

        private void InventoryInputCallback()
        {
            StateMachineUI.ToGameplayState();
        }

        #endregion
    }
}