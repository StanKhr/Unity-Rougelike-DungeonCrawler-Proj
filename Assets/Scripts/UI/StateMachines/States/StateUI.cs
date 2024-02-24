using System;
using FSM.Main;
using UI.StateMachines.Interfaces;

namespace UI.StateMachines.States
{
    public abstract class StateUI : State
    {
        #region Constructors

        protected StateUI(IStateMachineUI stateMachineUI)
        {
            StateMachineUI = stateMachineUI;
        }

        #endregion

        #region Properties

        protected IStateMachineUI StateMachineUI { get; }
        public override bool TickEnabled => false;

        #endregion

        #region Methods

        public override void Tick(float deltaTime)
        {
            
        }

        protected void EnableGameplayInputs(bool enable)
        {
            var inputProvider = StateMachineUI.InputProvider;
            
            inputProvider.Camera.EnableMap(enable);
            inputProvider.Movement.EnableMap(enable);
        }
        protected void SetInventoryCallback(Action callback, bool subscribe)
        {
            var inputProvider = StateMachineUI.InputProvider;
            if (subscribe)
            {
                inputProvider.Utility.OnInventory += callback;
                return;
            }
            
            inputProvider.Utility.OnInventory -= callback;
        }

        #endregion
    }
}