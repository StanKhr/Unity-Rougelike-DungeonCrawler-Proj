using FSM.Main;
using Miscellaneous;
using Player.Cameras.Enums;
using Player.StateMachines.Interfaces;
using Props.Interfaces;
using UnityEngine;

namespace Player.StateMachines.States
{
    public class StatePlayerFreeLook : State
    {
        #region Constructors

        public StatePlayerFreeLook(IStateMachinePlayer stateMachinePlayer)
        {
            StateMachinePlayer = stateMachinePlayer;
        }

        #endregion

        #region Properties

        private IStateMachinePlayer StateMachinePlayer { get; }

        #endregion

        #region Methods

        public override void Enter()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.Movement.OnJump += JumpCallback;
            
            inputProvider.Abilities.EnableMap(true);
            inputProvider.Abilities.OnInteracted += InteractedCallback;
            inputProvider.CursorVisibility.SetVisibility(false);
            
            var cameraWrapper = StateMachinePlayer.CameraWrapper;
            cameraWrapper.SetActiveCamera(ActiveCameraType.FreeLook);
        }

        public override void Exit()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.Camera.EnableMap(false);
            
            inputProvider.Movement.EnableMap(false);
            inputProvider.Movement.OnJump -= JumpCallback;
            
            inputProvider.Abilities.EnableMap(false);
            inputProvider.Abilities.OnInteracted -= InteractedCallback;
            inputProvider.CursorVisibility.SetVisibility(true);
        }

        public override void Tick(float deltaTime)
        {
            UpdateLocomotion(deltaTime);
        }

        private void InteractedCallback()
        {
            var eyeScanner = StateMachinePlayer.EyeScanner;
            if (!eyeScanner.Target)
            {
                return;
            }

            if (!eyeScanner.Target.TryGetComponent<IUsable>(out var usable))
            {
                return;
            }

            usable.TryUse(StateMachinePlayer.GameObject);
        }

        private void JumpCallback()
        {
            var locomotion = StateMachinePlayer.Locomotion;
            locomotion.ApplyJump();
        }

        private void UpdateLocomotion(float deltaTime)
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            var walking = inputProvider.Movement.Walking;
            var crouching = inputProvider.Movement.Crouching;
            var sprinting = inputProvider.Movement.Sprinting;
            
            var locomotion = StateMachinePlayer.Locomotion;
            locomotion.Walking = walking;
            locomotion.Crouching = crouching;
            locomotion.Sprinting = sprinting;
            
            var moveDirection = CalculateCameraDirection();
            
            locomotion.SetTargetMotion(moveDirection);
            locomotion.TickMotion(deltaTime);

            var footStepsTracker = StateMachinePlayer.FootStepsTracker;
            footStepsTracker.Tick(locomotion, deltaTime);
        }

        private Vector3 CalculateCameraDirection()
        {
            var cameraWrapper = StateMachinePlayer.CameraWrapper;
            var inputProvider = StateMachinePlayer.InputProvider;
            
            var forward = cameraWrapper.CameraForward;
            var right = cameraWrapper.CameraRight;

            forward.y = 0;
            right.y = 0;
            
            forward.Normalize();
            right.Normalize();

            var x = inputProvider.Movement.MoveInputs.x;
            var y = inputProvider.Movement.MoveInputs.y;
            
            return (forward * y + right * x).normalized;
        }

        #endregion
    }
}