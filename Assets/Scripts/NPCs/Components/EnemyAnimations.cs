using NPCs.Interfaces;
using UnityEngine;

namespace NPCs.Components
{
    public class EnemyAnimations : MonoBehaviour, IEnemyAnimations
    {
        #region Properties

        private const float MinVelocity = 0f;
        private const float MaxVelocity = 1f;

        #endregion
        
        #region Constants

        private static readonly int VelocityHash = Animator.StringToHash("Velocity");
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
            _animator.SetFloat(VelocityHash, MinVelocity);
        }

        public void PlayMovement()
        {
            _animator.SetFloat(VelocityHash, MaxVelocity);
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