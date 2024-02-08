using FSM.Main;
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
            inputProvider.CursorVisibility.SetVisibility(false);
        }

        public override void Exit()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.MapWrapperCamera.EnableMap(false);
            inputProvider.MapWrapperMovement.EnableMap(false);
            inputProvider.CursorVisibility.SetVisibility(true);
        }

        public override void Tick(float deltaTime)
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            var lookInputs = inputProvider.MapWrapperCamera.LookInputs;
            var cameraWrapper = StateMachinePlayer.CameraWrapper;
            
            cameraWrapper.SetLookInputs(lookInputs);

            var locomotion = StateMachinePlayer.Locomotion;
            var moveDirection = CalculateCameraDirection();
            locomotion.SetMoveDirection(moveDirection);
            
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
            
            return forward * y + right * x;
        }

        #endregion
    }
}