using FSM.Creatures.Machines;
using FSM.Main;
using Player.Cameras;
using Player.Cameras.Interfaces;
using Player.Inputs;
using Player.Inputs.Interfaces;
using Player.StateMachines.Interfaces;
using Player.StateMachines.States;
using UnityEngine;

namespace Player.StateMachines.Machines
{
    public class StateMachinePlayer : StateMachineHumanoid, IStateMachinePlayer
    {
        #region Editor Fields

        [SerializeField] private InputProvider _inputProvider;
        [SerializeField] private CameraWrapper _cameraWrapper;

        #endregion
        
        #region Properties

        public IInputProvider InputProvider => _inputProvider;
        public ICameraWrapper CameraWrapper => _cameraWrapper;

        #endregion

        #region Unity Callbacks

        protected override void Start()
        {
            base.Start();
            ToFreeLookState();
        }

        #endregion

        #region Methods

        public override void ToFreeLookState()
        {
            SwitchState(new StatePlayerFreeLook(this));
        }

        #endregion
    }
}