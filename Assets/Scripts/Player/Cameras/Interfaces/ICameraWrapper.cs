using System;
using Player.Cameras.Enums;
using UnityEngine;

namespace Player.Cameras.Interfaces
{
    public interface ICameraWrapper
    {
        #region Events

        event Action OnFootStepped;

        #endregion
        
        #region Properties

        Vector3 CameraForward { get; }
        Vector3 CameraRight { get; }

        #endregion
        
        #region Methods

        void SetActiveCamera(ActiveCameraType activeCameraType);
        void TickHeadBob(float magnitude, float deltaTime);

        #endregion
    }
}