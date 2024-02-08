using System;
using FSM.Main.Interfaces;

namespace FSM.Main
{
    public static class StateHelper
    {
        #region Methods
        
        public static bool ValidateStateType(Type stateType)
        {
            return typeof(IState).IsAssignableFrom(stateType);
        }

        #endregion
    }
}