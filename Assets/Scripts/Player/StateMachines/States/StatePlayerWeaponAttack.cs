using FSM.Main;
using Player.Inventories.Interfaces;
using Player.StateMachines.Interfaces;

namespace Player.StateMachines.States
{
    public class StatePlayerWeaponAttack : State
    {
        #region Constants

        public StatePlayerWeaponAttack(IStateMachinePlayer stateMachinePlayer, IWeapon weapon)
        {
            StateMachinePlayer = stateMachinePlayer;
            Weapon = weapon;
            ChargeTimeSeconds = Weapon.CalculateChargeTimeSeconds();
        }

        #endregion

        #region Properties

        private IStateMachinePlayer StateMachinePlayer { get; }
        private IWeapon Weapon { get; }
        private float ChargeTimeSeconds { get; }

        #endregion

        #region Methods

        public override void Enter()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.Camera.EnableMap(true);
            inputProvider.Abilities.OnWeaponAttackInputStateChanged += WeaponAttackInputStateChangedCallback;

            var playerAnimations = StateMachinePlayer.PlayerAnimations;
            playerAnimations.PlayWeaponAttackCharge(ChargeTimeSeconds);
        }

        public override void Exit()
        {
            var inputProvider = StateMachinePlayer.InputProvider;
            inputProvider.Camera.EnableMap(false);
            inputProvider.Abilities.OnWeaponAttackInputStateChanged -= WeaponAttackInputStateChangedCallback;
        }

        public override void Tick(float deltaTime)
        {
            
        }

        private void WeaponAttackInputStateChangedCallback(bool context)
        {
            if (context)
            {
                return;
            }
            
            
        }

        #endregion
    }
}