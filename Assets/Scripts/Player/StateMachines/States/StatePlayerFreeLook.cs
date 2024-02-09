using FSM.Main;
using Miscellaneous;
using Player.StateMachines.Interfaces;
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
            inputProvider.MapWrapperCamera.EnableMap(true);
            inputProvider.MapWrapperMovement.EnableMap(true);
            inputProvider.MapWrapperMovement.OnJump += JumpCallback;
            inputProvider.CursorVisibility.SetVisibility(false);
        }

        public override void Exit()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.MapWrapperCamera.EnableMap(false);
            inputProvider.MapWrapperMovement.EnableMap(false);
            inputProvider.MapWrapperMovement.OnJump -= JumpCallback;
            inputProvider.CursorVisibility.SetVisibility(true);
        }

        public override void Tick(float deltaTime)
        {
            UpdateCameraLook(deltaTime);
            UpdateLocomotion(deltaTime);
        }

        private void JumpCallback()
        {
            var locomotion = StateMachinePlayer.Locomotion;
            locomotion.ApplyJump();
        }

        private void UpdateCameraLook(float deltaTime)
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            var lookInputs = inputProvider.MapWrapperCamera.LookInputs;
            var cameraWrapper = StateMachinePlayer.CameraWrapper;
            
            cameraWrapper.SetLookInputs(lookInputs);
            
            var locomotion = StateMachinePlayer.Locomotion;
            if (!locomotion.Grounded)
            {
                cameraWrapper.TickHeadBob(0f, deltaTime);
                return;
            }
            
            cameraWrapper.TickHeadBob(locomotion.Velocity.magnitude, deltaTime);
        }

        private void UpdateLocomotion(float deltaTime)
        {
            var locomotion = StateMachinePlayer.Locomotion;
            var moveDirection = CalculateCameraDirection();
            
            locomotion.SetTargetDirection(moveDirection);
            locomotion.TickMovement(deltaTime);
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

            var x = inputProvider.MapWrapperMovement.MoveInputs.x;
            var y = inputProvider.MapWrapperMovement.MoveInputs.y;
            
            return (forward * y + right * x).normalized;
        }

        #endregion
    }
}