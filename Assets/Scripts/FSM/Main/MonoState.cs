using System;
using FSM.Main.Interfaces;
using UnityEngine;

namespace FSM.Main
{
    public abstract class MonoState : MonoBehaviour, IState
    {
        #region Properties

        public virtual int Priority => 0;
        public abstract bool TickEnabled { get; }
        public abstract bool UsesFixedUpdate { get; }
        public abstract bool UseUnscaledDeltaTime { get; }

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