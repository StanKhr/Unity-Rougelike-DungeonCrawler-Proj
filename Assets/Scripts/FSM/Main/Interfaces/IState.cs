using System;

namespace FSM.Main.Interfaces
{
    public interface IState
    {
        #region Properties

        int Priority { get; }
        bool TickEnabled { get; }
        bool UsesFixedUpdate { get; }
        bool UseUnscaledDeltaTime { get; }

        #endregion
        
        #region Methods

        void Enter();
        void Exit();
        void Tick(float deltaTime);
        bool CanBeSwitched(Type newStateType);

        #endregion
    }
}