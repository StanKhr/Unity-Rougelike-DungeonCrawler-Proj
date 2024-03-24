using System;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using UnityEngine;

namespace Abilities.Interfaces
{
    public interface ILocomotion
    {
        #region Events

        IEvent OnJumped { get; }
        IEvent OnGroundLanded { get; }
        IContextEvent<Events.FloatEvent> OnFallDamageTriggered { get; }

        #endregion
        
        #region Properties

        bool Walking { get; set; }
        bool Sprinting { get; set; }
        bool Crouching { get; set; }
        bool Grounded { get; }
        Vector3 BodyVelocity { get; }
        Vector3 Position { get; }

        #endregion
        
        #region Methods

        void ApplyJump();
        void SetTargetMotion(Vector3 newTargetDirection);
        void TickMotion(float deltaTime);
        void EnableCollider(bool enable);
        void Teleport(Vector3 position);

        #endregion
    }
}