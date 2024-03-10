using FSM.Main;
using Miscellaneous;
using NPCs.FSM.Interfaces;
using UnityEngine;

namespace NPCs.FSM.States
{
    public class StateEnemyFreeLook : StateEnemy
    {
        #region Constructors
        
        public StateEnemyFreeLook(IStateMachineEnemy stateMachineEnemy) : base(stateMachineEnemy)
        {
        }

        #endregion

        #region Fields


        
        #endregion

        #region Methods

        public override void Enter()
        {
            var locomotion = StateMachineEnemy.Locomotion;
            locomotion.SetTargetMotion(Vector3.zero);

            var enemyAnimations = StateMachineEnemy.EnemyAnimations;
            enemyAnimations.PlayIdle();
        }

        public override void Exit()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            var playerFinder = StateMachineEnemy.PlayerFinder;
            playerFinder.Tick(deltaTime);

            if (playerFinder.PlayerFound)
            {
                StateMachineEnemy.ToChasePlayerState();
                return;
            }
            
            var locomotion = StateMachineEnemy.Locomotion;
            locomotion.TickMotion(deltaTime);
        }

        #endregion
    }
}