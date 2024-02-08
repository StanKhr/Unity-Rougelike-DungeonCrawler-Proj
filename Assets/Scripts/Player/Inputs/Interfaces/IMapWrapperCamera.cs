using UnityEngine;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperCamera : IInputMapWrapper
    {
        #region Properties

        Vector2 Look { get; }

        #endregion
    }
}