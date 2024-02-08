using UnityEngine;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperMovement : IMapWrapper
    {
        #region Properties

        Vector2 MoveInputs { get; }

        #endregion
    }
}