using FSM.Main;
using Player.Inputs;
using Player.Inputs.Interfaces;
using UI.Presenters.Items;
using UI.StateMachines.Interfaces;
using UI.StateMachines.States;
using UnityEngine;

namespace UI.StateMachines.Machines
{
    public class StateMachineUI : StateMachine, IStateMachineUI
    {
        #region Editor Fields

        [SerializeField] private InputProvider _inputProvider;
        [SerializeField] private InventoryPresenter _inventoryPresenter;

        #endregion

        #region Properties

        public IInputProvider InputProvider => _inputProvider;
        public InventoryPresenter InventoryPresenter => _inventoryPresenter;

        #endregion

        #region Unity Callbacks

        protected override void Start()
        {
            base.Start();
            
            ToGameplayState();
        }

        #endregion

        #region Methods
        
        public void ToGameplayState()
        {
            SwitchState(new StateUIGameplay(this));
        }

        public void ToInventoryState()
        {
            SwitchState(new StateUIInventory(this));
        }

        #endregion
    }
}