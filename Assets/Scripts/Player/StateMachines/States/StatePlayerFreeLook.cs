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
            inputProvider.MapWrapperMovement.OnJump += JumpCallback;
            
            inputProvider.MapWrapperAbilities.EnableMap(true);
            inputProvider.MapWrapperAbilities.OnInteracted += InteractedCallback;
            inputProvider.CursorVisibility.SetVisibility(false);
            
            var cameraWrapper = StateMachinePlayer.CameraWrapper;
            cameraWrapper.SetActiveCamera(ActiveCameraType.FreeLook);
        }

        public override void Exit()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.MapWrapperCamera.EnableMap(false);
            
            inputProvider.MapWrapperMovement.EnableMap(false);
            inputProvider.MapWrapperMovement.OnJump -= JumpCallback;
            
            inputProvider.MapWrapperAbilities.EnableMap(false);
            inputProvider.MapWrapperAbilities.OnInteracted -= InteractedCallback;
            inputProvider.CursorVisibility.SetVisibility(true);
        }

        public override void Tick(float deltaTime)
        {
            UpdateCameraLook(deltaTime);
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
            // LogWriter.DevelopmentLog($"Trying to interact with: {eyeScanner.Target}");
        }

        private void JumpCallback()
        {
            var locomotion = StateMachinePlayer.Locomotion;
            locomotion.ApplyJump();
        }

        private void UpdateCameraLook(float deltaTime)
        {
            var cameraWrapper = StateMachinePlayer.CameraWrapper;
            
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