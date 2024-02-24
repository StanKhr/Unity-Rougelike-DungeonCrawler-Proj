using System;
using Player.Cameras.Enums;
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

        void SetActiveCamera(ActiveCameraType activeCameraType);

        #endregion
    }
}