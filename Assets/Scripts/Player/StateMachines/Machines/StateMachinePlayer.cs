using FSM.Creatures.Machines;
using Player.Attacks;
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
        [SerializeField] private FootStepsTracker _footStepsTracker;
        [SerializeField] private Gear _gear;
        [SerializeField] private PlayerAnimations _playerAnimations;
        [SerializeField] private AttackDamageApplier _attackDamageApplier;

        #endregion
        
        #region Properties

        public IInputProvider InputProvider => _inputProvider;
        public ICameraWrapper CameraWrapper => _cameraWrapper;
        public IEyeScanner EyeScanner => _eyeScanner;
        public IFootStepsTracker FootStepsTracker => _footStepsTracker;
        public IInventory Inventory => _inventory;
        public IGear Gear => _gear;
        public IPlayerAnimations PlayerAnimations => _playerAnimations;
        public IAttackDamageApplier AttackDamageApplier => _attackDamageApplier;

        #endregion

        #region Unity Callbacks

        protected override void Start()
        {
            base.Start();
            ToFreeLookState();
        }

        #endregion

        #region Methods
        
        public void ToWeaponAttackState(IWeapon weapon)
        {
            SwitchState(new StatePlayerWeaponAttack(this, weapon));
        }

        public override void ToFreeLookState()
        {
            SwitchState(new StatePlayerFreeLook(this));
        }

        public override void ToDeathState()
        {
            SwitchState(new StatePlayerDeath(this));
        }
        
        public Vector3 CalculateCameraDirection()
        {
            var forward = CameraWrapper.CameraForward;
            var right = CameraWrapper.CameraRight;

            forward.y = 0;
            right.y = 0;
            
            forward.Normalize();
            right.Normalize();

            var x = InputProvider.Movement.MoveInputs.x;
            var y = InputProvider.Movement.MoveInputs.y;
            
            return (forward * y + right * x).normalized;
        }
        
        #endregion
    }
}