using FSM.Main;
using Player.StateMachines.Interfaces;

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
            inputProvider.CursorVisibility.SetVisibility(false);
        }

        public override void Exit()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.MapWrapperCamera.EnableMap(false);
            inputProvider.CursorVisibility.SetVisibility(true);
        }

        public override void Tick(float deltaTime)
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            var lookInputs = inputProvider.MapWrapperCamera.Look;
            var cameraWrapper = StateMachinePlayer.CameraWrapper;
            
            cameraWrapper.SetLookInputs(lookInputs);
        }

        #endregion
    }
}