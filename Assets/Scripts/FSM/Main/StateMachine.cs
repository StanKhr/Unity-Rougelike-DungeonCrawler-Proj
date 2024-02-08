using System;
using FSM.Main.Interfaces;
using UnityEngine;

namespace FSM.Main
{
    public abstract class StateMachine : MonoBehaviour
    {
        #region Fields

        private IState _activeState;
        private IStateMachineCallbacks _stateMachineCallbacks;

        #endregion

        #region Properties
        
        public IState ActiveState
        {
            get => _activeState;
            private set
            {
                if (_activeState == value)
                {
                    return;
                }

                _activeState?.Exit();
                _activeState = value;
                _activeState?.Enter();
                
                _stateMachineCallbacks?.CallStateChanged(this, _activeState);

// #if UNITY_EDITOR
//                 Debug.Log($"{name} enters state: {_activeState?.GetType().Name}");
// #endif
            }
        }

        #endregion

        #region Unity Callbacks

        protected virtual void Start()
        {
            TryGetComponent(out _stateMachineCallbacks);
        }

        private void Update()
        {
            if (ActiveState == null)
            {
                return;
            }
            
            if (!ActiveState.TickEnabled)
            {
                return;
            }

            if (ActiveState.UsesFixedUpdate)
            {
                return;
            }

            var time = !ActiveState.UseUnscaledDeltaTime ? Time.deltaTime : Time.unscaledDeltaTime;
            ActiveState.Tick(time);
        }

        private void FixedUpdate()
        {
            if (ActiveState == null)
            {
                return;
            }

            if (!ActiveState.TickEnabled)
            {
                return;
            }

            if (!ActiveState.UsesFixedUpdate)
            {
                return;
            }
            
            var time = !ActiveState.UseUnscaledDeltaTime ? Time.fixedDeltaTime : Time.fixedUnscaledDeltaTime;
            ActiveState?.Tick(time);
        }

        protected virtual void OnDestroy()
        {
            ActiveState = null;
        }

        #endregion

        #region Methods

        protected bool SwitchState(IState newState, bool ignorePriority = false)
        {
            if (newState == null)
            {
                return false;
            }
            
            if (ActiveState != null)
            {
                if (!ignorePriority && ActiveState.Priority > newState.Priority)
                {
                    return false;
                }
                
                if (!ActiveState.CanBeSwitched(newState.GetType()))
                {
                    return false;
                }
            }
            
            ActiveState = newState;
            return true;
        }

        public bool ExitCurrentState()
        {
            if (ActiveState == null)
            {
                return false;
            }

            ActiveState = null;
            return true;
        }

        private bool StateIsSubclass(Type stateObjectType)
        {
            var checkSubclass = StateHelper.ValidateStateType(stateObjectType);
            return checkSubclass;
        }

        #endregion
    }
}