using System;
using Miscellaneous.EventWrapper.Interfaces;
using UnityEngine;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperMovement : IMapWrapper
    {
        #region Events

        IEvent OnJump { get; }

        #endregion
        
        #region Properties

        Vector2 MoveInputs { get; }
        bool Sprinting { get; }
        bool Crouching { get; }
        bool Walking { get; }

        #endregion
    }
}