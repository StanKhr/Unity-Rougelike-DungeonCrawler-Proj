using FSM.Main;
using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.StateMachines.Interfaces;
using UnityEngine;

namespace Player.StateMachines.States
{
    public class StatePlayerWeaponAttack : State
    {
        #region Constants

        private const float MinChargeTime = 0.1f;
        private const float ReleaseAnimationTimeSeconds = 0.5f;

        #endregion
        
        #region Constants

        public StatePlayerWeaponAttack(IStateMachinePlayer stateMachinePlayer, IWeapon weapon)
        {
            StateMachinePlayer = stateMachinePlayer;
            Weapon = weapon;
            ChargeTimeSeconds = Weapon.CalculateChargeTimeSeconds();
        }

        #endregion

        #region Fields

        private float _timer;
        private bool _released;
        private bool _damageApplied;

        #endregion

        #region Properties

        private IStateMachinePlayer StateMachinePlayer { get; }
        private IWeapon Weapon { get; }
        private float ChargeTimeSeconds { get; }
        private float Timer
        {
            get => _timer;
            set => _timer = Mathf.Clamp(value, 0f, ChargeTimeSeconds);
        }

        #endregion

        #region Methods

        public override void Enter()
        {
            var playerAnimations = StateMachinePlayer.PlayerAnimations;
            playerAnimations.PlayWeaponAttackCharge(ChargeTimeSeconds);
        }

        public override void Exit()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            UpdateLocomotion(deltaTime);
            
            if (_damageApplied)
            {
                if (Timer <= 0f)
                {
                    StateMachinePlayer.ToFreeLookState();
                    return;
                }

                Timer -= deltaTime;
                return;
            }
            
            if (!_released)
            {
                Timer += deltaTime;

                var inputProvider = StateMachinePlayer.InputProvider;
                var holdingInput = inputProvider.Abilities.AttackInputHolding;
                
                LogWriter.DevelopmentLog($"Holding input: {holdingInput.ToString()}");
                
                if (!holdingInput && Timer >= MinChargeTime)
                {
                    _released = true;
                }
                
                return;
            }

            var playerAnimations = StateMachinePlayer.PlayerAnimations;
            playerAnimations.PlayWeaponAttackRelease();

            _damageApplied = true;

            var damageValue = CalculateDamageValue(Timer);
            
            LogWriter.DevelopmentLog($"Damage: {damageValue.ToString("F")}; charge time: {Timer.ToString("F")}");
            
            Timer = ReleaseAnimationTimeSeconds;
        }

        private void UpdateLocomotion(float deltaTime)
        {
            var locomotion = StateMachinePlayer.Locomotion;
            locomotion.Walking = true;
            
            var moveDirection = StateMachinePlayer.CalculateCameraDirection();
            
            locomotion.SetTargetMotion(moveDirection);
            locomotion.TickMotion(deltaTime);

            var footStepsTracker = StateMachinePlayer.FootStepsTracker;
            footStepsTracker.Tick(locomotion, deltaTime);
        }

        private float CalculateDamageValue(float chargeTime)
        {
            return Weapon.DamageValue * (chargeTime / ChargeTimeSeconds);
        }

        #endregion
    }
}