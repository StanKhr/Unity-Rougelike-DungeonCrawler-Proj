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

        #endregion
    }
}