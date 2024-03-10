using System;
using NPCs.FSM.Interfaces;
using UnityEngine;

namespace NPCs.FSM.States
{
    public class StateEnemyChasePlayer : StateEnemy
    {
        #region Constructors

        public StateEnemyChasePlayer(IStateMachineEnemy stateMachineEnemy) : base(stateMachineEnemy)
        {
        }

        #endregion

        #region Methods

        public override void Enter()
        {
            var navMeshAgentWrapper = StateMachineEnemy.NavMeshAgentWrapper;
            navMeshAgentWrapper.EnableAgent(true);

            var locomotion = StateMachineEnemy.Locomotion;
            navMeshAgentWrapper.TeleportAgent(locomotion.BodyVelocity);
        }

        public override void Exit()
        {
            var navMeshAgentWrapper = StateMachineEnemy.NavMeshAgentWrapper;
            navMeshAgentWrapper.EnableAgent(false);
        }

        public override void Tick(float deltaTime)
        {
            var playerFinder = StateMachineEnemy.PlayerFinder;
            if (!playerFinder.PlayerFound)
            {
                StateMachineEnemy.ToFreeLookState();
                return;
            }
            
            var navMeshAgentWrapper = StateMachineEnemy.NavMeshAgentWrapper;    
            var playerPosition = playerFinder.PlayerPosition;
            var locomotion = StateMachineEnemy.Locomotion;

            Vector3 direction;
            
            if (navMeshAgentWrapper.IsOnNavMesh)
            {
                navMeshAgentWrapper.Destination = playerPosition;

                direction = navMeshAgentWrapper.NormalizedDesiredVelocity;
            }
            else
            {
                direction = (playerPosition - locomotion.Position).normalized;
            }
            
            locomotion.SetTargetMotion(direction);
            locomotion.TickMotion(deltaTime);
            
            navMeshAgentWrapper.Velocity = locomotion.BodyVelocity;
        }

        #endregion
    }
}