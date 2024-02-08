using FSM.Main.Interfaces;
using UnityEngine;

namespace FSM.Main
{
    public class StateMachineDebug : MonoBehaviour, IStateMachineCallbacks
    {
        #region Methods

        public void CallStateChanged(StateMachine stateMachine, IState newState)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (newState == null)
            {
                Debug.Log($"{stateMachine.name}'s state switched to NULL");
                return;
            }

            Debug.Log($"{stateMachine.name}'s state switched: {newState.GetType().Name}");
#endif
        }

        #endregion
    }
}