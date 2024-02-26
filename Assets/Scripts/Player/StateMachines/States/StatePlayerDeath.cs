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

            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.Abilities.EnableMap(true);
            inputProvider.Abilities.OnTestInputPressed += TestInputPressedCallback;
        }

        public override void Exit()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.Abilities.EnableMap(false);
            inputProvider.Abilities.OnTestInputPressed -= TestInputPressedCallback;
        }

        public override void Tick(float deltaTime)
        {
            var locomotion = StateMachinePlayer.Locomotion;
            
            locomotion.SetTargetMotion(Vector3.zero);
            locomotion.TickMotion(deltaTime);
        }

        private void TestInputPressedCallback()
        {
            StateMachinePlayer.Resurrect();
        }

        #endregion
    }
}