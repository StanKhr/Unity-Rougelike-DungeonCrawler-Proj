using UnityEngine;

namespace Player.Cameras.Interfaces
{
    public interface ICameraWrapper
    {
        #region Properties

        Vector3 CameraForward { get; }
        Vector3 CameraRight { get; }

        #endregion
        
        #region Methods

        void SetLookInputs(Vector2 inputs);

        #endregion
    }
}