using UnityEngine;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperCamera : IMapWrapper
    {
        #region Properties

        Vector2 LookInputs { get; }

        #endregion
    }
}