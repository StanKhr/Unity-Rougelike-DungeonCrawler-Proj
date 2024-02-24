using System;
using Abilities.Interfaces;
using UnityEngine;

namespace Abilities.Locomotion
{
    [Serializable]
    public struct LocomotionData
    {
        #region Constants

        private const float BaseMotionChangeRate = 1f;

        #endregion
        
        #region Editor Fields

        [field: SerializeField, Min(0f)] private float RunSpeed { get; set; }
        [field: SerializeField, Min(1f)] private float SprintMultiplier { get; set; }
        [field: SerializeField, Range(0f, 1f)] private float CrouchMultiplier { get; set; }
        [field: SerializeField, Range(0f, 1f)] private float WalkMultiplier { get; set; }
        [field: SerializeField] private float MotionChangeRateGround { get; set; }
        [field: SerializeField] private float MotionChangeRateAir { get; set; }

        #endregion
        #region Public Editor Fields

        [field: SerializeField, Min(0f), Header("Public Fields")] public float JumpPower { get; private set; }
        [field: SerializeField, Min(0f)] public float GravityScale { get; private set; }
        [field: SerializeField] public float FallDamageGravityThreshold { get; private set; }

        #endregion
        
        #region Methods

        public float GetSpeed(ILocomotion locomotion, bool modifiersIncluded = true)
        {
            if (!modifiersIncluded)
            {
                return RunSpeed;
            }

            if (locomotion.Walking)
            {
                return RunSpeed * WalkMultiplier;
            }

            if (locomotion.Crouching)
            {
                return RunSpeed * CrouchMultiplier;
            }

            if (locomotion.Sprinting)
            {
                return RunSpeed * SprintMultiplier;
            }

            return RunSpeed;
        }

        public float GetMotionChangeRate(ILocomotion locomotion)
        {
            if (locomotion.Grounded)
            {
                return MotionChangeRateGround > 0f ? MotionChangeRateGround : BaseMotionChangeRate;
            }
            
            return MotionChangeRateAir > 0f ? MotionChangeRateAir : BaseMotionChangeRate;
        }

        #endregion
    }
}