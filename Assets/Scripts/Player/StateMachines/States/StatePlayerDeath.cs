using FSM.Main;
using Player.Cameras.Enums;
using Player.StateMachines.Interfaces;
using UnityEngine;

namespace Player.StateMachines.States
{
    public class StatePlayerDeath : State
    {
        #region Constructors

        public StatePlayerDeath(IStateMachinePlayer stateMachinePlayer)
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
            var cameraWrapper = StateMachinePlayer.CameraWrapper;
            cameraWrapper.SetActiveCamera(ActiveCameraType.Death);
        }

        public override void Exit()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            var locomotion = StateMachinePlayer.Locomotion;
            
            locomotion.SetTargetDirection(Vector3.zero);
            locomotion.TickMovement(deltaTime);
        }

        #endregion
    }
}