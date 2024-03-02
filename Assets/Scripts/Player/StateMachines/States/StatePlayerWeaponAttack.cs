using FSM.Main;
using Player.Attacks;
using Player.Inventories.Interfaces;
using Player.StateMachines.Interfaces;

namespace Player.StateMachines.States
{
    public class StatePlayerWeaponAttack : State
    {
        #region Constants


        #endregion
        
        #region Constants

        public StatePlayerWeaponAttack(IStateMachinePlayer stateMachinePlayer, IWeapon weapon)
        {
            StateMachinePlayer = stateMachinePlayer;
            Weapon = weapon;
        }

        #endregion

        #region Properties

        private IStateMachinePlayer StateMachinePlayer { get; }
        private IWeapon Weapon { get; }
        
        #endregion

        #region Methods

        public override void Enter()
        {
            var playerAttack = StateMachinePlayer.PlayerMeleeAttack;
            playerAttack.OnAttackChargeStarted += AttackChargeStartedCallback;
            playerAttack.OnAttackEnded += AttackEndedCallback;
            playerAttack.OnAttackReleased += AttackReleasedCallback;
            
            playerAttack.ChargeAttack(Weapon);
        }

        public override void Exit()
        {
            var playerAttack = StateMachinePlayer.PlayerMeleeAttack;
            
            playerAttack.OnAttackChargeStarted -= AttackChargeStartedCallback;
            playerAttack.OnAttackEnded -= AttackEndedCallback;
            playerAttack.OnAttackReleased -= AttackReleasedCallback;
            
            playerAttack.InterruptAttack();
        }

        public override void Tick(float deltaTime)
        {
            UpdateLocomotion(deltaTime);

            var playerMeleeAttack = StateMachinePlayer.PlayerMeleeAttack;
            
            playerMeleeAttack.Tick(deltaTime);

            if (!playerMeleeAttack.ChargingAttack)
            {
                return;
            }
            
            var inputProvider = StateMachinePlayer.InputProvider;
            var holdingInput = inputProvider.Abilities.AttackInputHolding;

            if (holdingInput)
            {
                return;
            }

            playerMeleeAttack.ReleaseAttack();
        }

        private void AttackReleasedCallback(IWeapon weapon)
        {
            var playerAnimations = StateMachinePlayer.PlayerAnimations;
            playerAnimations.PlayWeaponAttackRelease();
        }

        private void AttackEndedCallback()
        {
            StateMachinePlayer.ToFreeLookState();
        }

        private void AttackChargeStartedCallback(MeleeAttackData context)
        {
            var playerAnimations = StateMachinePlayer.PlayerAnimations;
            playerAnimations.PlayWeaponAttackCharge(Weapon.CalculateChargeTimeSeconds());
        }

        private void UpdateLocomotion(float deltaTime)
        {
            var locomotion = StateMachinePlayer.Locomotion;
            // if (!locomotion.Grounded)
            // {
            //     var playerMeleeAttack = StateMachinePlayer.PlayerMeleeAttack;
            //     playerMeleeAttack.InterruptAttack();
            //     
            //     return;
            // }
            
            locomotion.Walking = true;
            
            var moveDirection = StateMachinePlayer.CalculateCameraDirection();
            
            locomotion.SetTargetMotion(moveDirection);
            locomotion.TickMotion(deltaTime);

            var footStepsTracker = StateMachinePlayer.FootStepsTracker;
            footStepsTracker.Tick(locomotion, deltaTime);
        }

        #endregion
    }
}