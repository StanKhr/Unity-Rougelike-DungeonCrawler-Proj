using System;
using NPCs.Interfaces;
using UnityEngine;

namespace NPCs.Components
{
    public class EnemyAnimations : MonoBehaviour, IEnemyAnimations
    {
        #region Constants

        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private static readonly int MovementHash = Animator.StringToHash("Movement");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int DeathHash = Animator.StringToHash("Death");

        #endregion

        #region Editor Fields

        [SerializeField] private Animator _animator;

        #endregion
        
        #region Methods

        public void PlayIdle()
        {
            PlayAnimation(IdleHash);
        }

        public void PlayMovement()
        {
            PlayAnimation(MovementHash);
        }

        public void PlayAttack()
        {
            PlayAnimation(AttackHash);
        }

        public void PlayDeath()
        {
            PlayAnimation(DeathHash);
        }

        private void PlayAnimation(int hash)
        {
            _animator.Play(hash);
        }

        #endregion
    }
}