using Abilities.Interfaces;
using Abilities.Locomotion;
using FSM.Creatures.Interfaces;
using FSM.Main;
using UnityEngine;

namespace FSM.Creatures.Machines
{
    public abstract class StateMachineHumanoid : StateMachine, IStateMachineHumanoid
    {
        #region Editor Fields

        [SerializeField] private LocomotionCharacterController _locomotionCharacterController;

        #endregion

        #region Properties

        public ILocomotion Locomotion => _locomotionCharacterController;

        #endregion
    }
}