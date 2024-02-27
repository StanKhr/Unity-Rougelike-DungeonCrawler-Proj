﻿using FSM.Main;
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
            inputProvider.Camera.EnableMap(true);
            
            inputProvider.Movement.OnJump += JumpCallback;
            
            inputProvider.Abilities.EnableMap(true);
            inputProvider.Abilities.OnInteracted += InteractedCallback;
            inputProvider.Abilities.OnWeaponAttackInputStateChanged += WeaponAttackInputStateChangedCallback;
            
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
            inputProvider.Abilities.OnWeaponAttackInputStateChanged -= WeaponAttackInputStateChangedCallback;
        }

        public override void Tick(float deltaTime)
        {
            UpdateLocomotion(deltaTime);
        }

        private void WeaponAttackInputStateChangedCallback(bool context)
        {
            if (!context)
            {
                return;
            }

            var gear = StateMachinePlayer.Gear;
            if (!gear.WeaponEquipped)
            {
                return;
            }

            var weapon = gear.Weapon;
            StateMachinePlayer.ToWeaponAttackState(weapon);
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
            
            var moveDirection = StateMachinePlayer.CalculateCameraDirection();
            
            locomotion.SetTargetMotion(moveDirection);
            locomotion.TickMotion(deltaTime);

            var footStepsTracker = StateMachinePlayer.FootStepsTracker;
            footStepsTracker.Tick(locomotion, deltaTime);
        }

        #endregion
    }
}