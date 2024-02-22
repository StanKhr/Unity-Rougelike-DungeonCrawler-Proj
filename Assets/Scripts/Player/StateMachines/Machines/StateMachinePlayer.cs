using FSM.Creatures.Machines;
using FSM.Main;
using Player.Cameras;
using Player.Cameras.Interfaces;
using Player.Inputs;
using Player.Inputs.Interfaces;
using Player.Interfaces;
using Player.Inventories;
using Player.Inventories.Interfaces;
using Player.Miscellaneous;
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
        [SerializeField] private EyeScanner _eyeScanner;
        [SerializeField] private Inventory _inventory;

        #endregion
        
        #region Properties

        public IInputProvider InputProvider => _inputProvider;
        public ICameraWrapper CameraWrapper => _cameraWrapper;
        public IEyeScanner EyeScanner => _eyeScanner;
        public IInventory Inventory => _inventory;

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

        public override void ToDeathState()
        {
            SwitchState(new StatePlayerDeath(this));
        }

        #endregion
    }
}