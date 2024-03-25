﻿using NPCs.FSM.Interfaces;
using UnityEngine;

namespace NPCs.FSM.States
{
    public class StateEnemyAttack : StateEnemy
    {
        #region Constructors

        public StateEnemyAttack(IStateMachineEnemy stateMachineEnemy) : base(stateMachineEnemy)
        {
            
        }

        #endregion

        #region Fields

        private float _attackChargeTimer;
        private float _attackReleaseTimer;
        private bool _attackReleased;

        #endregion

        #region Methods

        public override void Enter()
        {
            var locomotion = StateMachineEnemy.Locomotion;
            locomotion.SetTargetMotion(Vector3.zero);
            
            var enemyAttack = StateMachineEnemy.EnemyAttack;
            _attackChargeTimer = enemyAttack.AttackChargeTime;
            _attackReleaseTimer = enemyAttack.AttackReleaseTime;

            var enemyAnimations = StateMachineEnemy.EnemyAnimations;
            enemyAnimations.PlayAttack();
        }

        public override void Exit()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            UpdateVelocity(deltaTime);
            
            if (_attackChargeTimer > 0f)
            {
                _attackChargeTimer -= deltaTime;
                return;
            }

            if (_attackReleased)
            {
                if (_attackReleaseTimer > 0f)
                {
                    _attackReleaseTimer -= deltaTime;
                    return;
                }
                
                StateMachineEnemy.ToChasePlayerState();
                return;
            }

            _attackReleased = true;
            
            var enemyAttack = StateMachineEnemy.EnemyAttack;
            var playerFinder = StateMachineEnemy.PlayerFinder;
            enemyAttack.PerformAttack(playerFinder.PlayerPosition);
        }

        private void UpdateVelocity(float deltaTime)
        {
            var locomotion = StateMachineEnemy.Locomotion;
            locomotion.TickMotion(deltaTime);

            var enemyAnimations = StateMachineEnemy.EnemyAnimations;
            enemyAnimations.SetLocomotionVelocity(locomotion.BodyVelocity.magnitude);
        }

        #endregion
    }
}