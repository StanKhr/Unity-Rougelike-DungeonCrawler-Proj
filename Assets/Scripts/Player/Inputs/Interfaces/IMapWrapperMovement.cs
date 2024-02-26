using System;
using UnityEngine;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperMovement : IMapWrapper
    {
        #region Events

        event Action OnJump;

        #endregion
        
        #region Properties

        Vector2 MoveInputs { get; }
        bool Sprinting { get; }
        bool Crouching { get; }
        bool Walking { get; }

        #endregion
    }
}