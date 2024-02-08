using FSM.Creatures.Machines;
using FSM.Main;
using Player.Inputs;
using Player.Inputs.Interfaces;
using Player.StateMachines.Interfaces;
using UnityEngine;

namespace Player.StateMachines.Machines
{
    public class StateMachinePlayer : StateMachineHumanoid, IStateMachinePlayer
    {
        #region Editor Fields

        [SerializeField] private InputProvider _inputProvider;

        #endregion
        
        #region Properties

        public IInputProvider InputProvider => _inputProvider;

        #endregion

    }
}