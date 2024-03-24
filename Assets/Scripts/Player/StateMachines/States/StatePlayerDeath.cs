using System;
using FSM.Main;
using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Player.Cameras.Enums;
using Player.StateMachines.Interfaces;
using UnityEngine;

namespace Player.StateMachines.States
{
    public class StatePlayerDeath : State
    {
        #region Constants

        private const float GameLoopNotificationDelaySeconds = 4f;

        #endregion

        #region Events

        public static IEvent OnPlayerDied { get; } = new CustomEvent();

        #endregion
        
        #region Constructors

        public StatePlayerDeath(IStateMachinePlayer stateMachinePlayer)
        {
            StateMachinePlayer = stateMachinePlayer;
        }
        
		#endregion

        #region Properties

        private IStateMachinePlayer StateMachinePlayer { get; }

        #endregion

        #region Fields

        private float _notificationDelay;

        #endregion

        #region Methods
        
        public override void Enter()
        {
            ResetNotificationDelay();
            
            var cameraWrapper = StateMachinePlayer.CameraWrapper;
            cameraWrapper.SetActiveCamera(ActiveCameraType.Death);

            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.Abilities.EnableMap(true);
        }

        public override void Exit()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.Abilities.EnableMap(false);
        }

        public override void Tick(float deltaTime)
        {
            var locomotion = StateMachinePlayer.Locomotion;
            
            locomotion.SetTargetMotion(Vector3.zero);
            locomotion.TickMotion(deltaTime);

            if (_notificationDelay > 0f)
            {
                _notificationDelay -= deltaTime;
                return;
            }
            
            ResetNotificationDelay();
            OnPlayerDied?.NotifyListeners();
        }

        private void ResetNotificationDelay()
        {
            _notificationDelay = GameLoopNotificationDelaySeconds;
        }

        #endregion
    }
}