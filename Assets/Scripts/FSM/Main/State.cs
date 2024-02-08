using System;
using FSM.Main.Interfaces;

namespace FSM.Main
{
    public abstract class State : IState
    {
        #region Properties

        public virtual int Priority => 0;
        public virtual bool TickEnabled => true;
        public virtual bool UsesFixedUpdate => false;
        public virtual bool UseUnscaledDeltaTime => false;

        #endregion
        
        #region Methods

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Tick(float deltaTime);
        public virtual bool CanBeSwitched(Type newStateType)
        {
            return StateHelper.ValidateStateType(newStateType);
        }
        
        #endregion
    }
}