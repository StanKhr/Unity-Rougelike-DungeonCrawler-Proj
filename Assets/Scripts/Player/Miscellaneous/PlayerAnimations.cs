using Player.Interfaces;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class PlayerAnimations : MonoBehaviour, IPlayerAnimations
    {
        #region Constants

        private const float AttackChargeBaseSpeedMultiplier = 1f;
        private const float DefaultTransitionTime = 0.1f;

        private static readonly int HandsBaseLoopHash = Animator.StringToHash("Hands Base Loop");
        private static readonly int AttackChargeHash = Animator.StringToHash("Attack Charge");
        private static readonly int AttackSpeedMultiplierHash = Animator.StringToHash("AttackSpeedMultiplier");
        private static readonly int AttackReleaseHash = Animator.StringToHash("Attack Release");

        #endregion

        #region Editor Fields

        [SerializeField] private Animator _animator;

        #endregion
        
        #region Methods

        public void ResetHandsAnimation()
        {
            CrossFadeAnimation(HandsBaseLoopHash);
        }

        public void PlayWeaponAttackCharge(float weaponAttackSpeed)
        {
            var attackChargeSpeed = CalculateAttackChargeSpeed(weaponAttackSpeed);
            _animator.SetFloat(AttackSpeedMultiplierHash, attackChargeSpeed);
            CrossFadeAnimation(AttackChargeHash);
        }

        public void PlayWeaponAttackRelease()
        {
            CrossFadeAnimation(AttackReleaseHash);
        }

        private void CrossFadeAnimation(int animationNameHash)
        {
            _animator.CrossFade(animationNameHash, DefaultTransitionTime);
        }

        private float CalculateAttackChargeSpeed(float weaponAttackSpeed)
        {
            if (weaponAttackSpeed <= 0f)
            {
                return AttackChargeBaseSpeedMultiplier;
            }

            return 1f / weaponAttackSpeed;
        }

        #endregion
    }
}