using System;
using Abilities.Interfaces;
using UnityEngine;

namespace Abilities.Locomotion
{
    [Serializable]
    public struct LocomotionData
    {
        #region Editor Fields

        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpPower { get; private set; }
        [field: SerializeField] public float GravityScale { get; private set; }
        [field: SerializeField, Min(0f)] private float AccelerationGround { get; set; }
        [field: SerializeField, Min(0f)] private float AccelerationAir { get; set; }

        #endregion

        #region Methods

        public float GetAppropriateAcceleration(ILocomotion locomotion)
        {
            if (!locomotion.Grounded)
            {
                return AccelerationAir;
            }
            
            return AccelerationGround;
        }

        #endregion
    }
}