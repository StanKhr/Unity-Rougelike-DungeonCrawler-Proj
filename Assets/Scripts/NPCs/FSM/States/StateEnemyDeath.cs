using NPCs.FSM.Interfaces;
using UnityEngine;

namespace NPCs.FSM.States
{
    public class StateEnemyDeath : StateEnemy
    {
        #region Constructors

        public StateEnemyDeath(IStateMachineEnemy stateMachineEnemy) : base(stateMachineEnemy)
        {
            
        }

        #endregion

        #region Methods

        public override void Enter()
        {
            var locomotion = StateMachineEnemy.Locomotion;
            locomotion.SetTargetMotion(Vector3.zero);
            
            var enemyAnimations = StateMachineEnemy.EnemyAnimations;
            enemyAnimations.PlayDeath();
        }

        public override void Exit()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            
        }

        #endregion
    }
}