using FSM.Main;
using UI.StateMachines.Interfaces;
using UI.StateMachines.States;
using UnityEngine;

namespace UI.StateMachines.Machines
{
    public class StateMachineUI : StateMachine, IStateMachineUI
    {
        #region Editor Fields

        [SerializeField] private RectTransform _inventoryPresenter;

        #endregion

        #region Properties
        
        

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

        #endregion
    }
}