using System;
using FSM.Main;
using Player.Inputs.Interfaces;
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
        private IInputProvider InputProvider => StateMachineUI.InputProvider;
        public override bool TickEnabled => false;

        #endregion

        #region Methods

        public override void Tick(float deltaTime)
        {
            
        }

        protected void EnableCursor(bool enable)
        {
            InputProvider.CursorVisibility.SetVisibility(enable);
        }

        protected void EnableGameplayInputs(bool enable)
        {
            InputProvider.Camera.EnableMap(enable);
            InputProvider.Movement.EnableMap(enable);
            InputProvider.Abilities.EnableMap(enable);
        }
        
        protected void SetInventoryCallback(Action callback, bool subscribe)
        {
            if (subscribe)
            {
                InputProvider.Utility.OnInventory += callback;
                return;
            }
            
            InputProvider.Utility.OnInventory -= callback;
        }

        protected void SetPauseMenuCallback(Action callback, bool subscribe)
        {
            if (subscribe)
            {
                InputProvider.Utility.OnPauseMenu += callback;
                return;
            }
            
            InputProvider.Utility.OnPauseMenu -= callback;
        }

        protected void SetDiscardButtonCallback(Action callback, bool subscribe)
        {
            if (subscribe)
            {
                InputProvider.Utility.OnDiscardPressed += callback;
                return;
            }
            
            InputProvider.Utility.OnDiscardPressed -= callback;
        }

        #endregion
    }
}