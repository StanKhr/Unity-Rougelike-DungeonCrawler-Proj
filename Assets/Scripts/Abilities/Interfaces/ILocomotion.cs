using System;
using Miscellaneous;
using UnityEngine;

namespace Abilities.Interfaces
{
    public interface ILocomotion
    {
        #region Events

        event Action OnJumped;
        event Action OnGroundLanded;
        event DelegateHolder.FloatEvents OnFallDamageTriggered;

        #endregion
        
        #region Properties

        bool Walking { get; set; }
        bool Sprinting { get; set; }
        bool Crouching { get; set; }
        bool Grounded { get; }
        Vector3 BodyVelocity { get; }

        #endregion
        
        #region Methods

        void ApplyJump();
        void SetTargetMotion(Vector3 newTargetDirection);
        void TickMotion(float deltaTime);

        #endregion
    }
}