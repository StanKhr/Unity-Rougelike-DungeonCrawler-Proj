using System;
using Cinemachine;
using Player.Cameras.Enums;
using Player.Cameras.Interfaces;
using Player.Inputs;
using UnityEngine;

namespace Player.Cameras
{
    public class CameraWrapper : MonoBehaviour, ICameraWrapper
    {
        #region Constants

        private const float HeadBobDelayTime = 0.45f;
        private const int PriorityLow = 1;
        private const int PriorityHigh = 10;

        #endregion

        #region Events
        
        public event Action OnFootStepped;

        #endregion

        #region Editor Fields

        [Header("Cinemachine Cameras")]
        [SerializeField] private CinemachineVirtualCamera _cinemachineFreeLook;
        [SerializeField] private CinemachineVirtualCamera _cinemachineDeath;
        
        [Header("References")]
        [field: SerializeField] public CinemachineExtensionFirstPersonInputs _cinemachineExtensionFirstPersonInputs;
        [field: SerializeField] public CinemachineImpulseSource _cinemachineImpulseSource;

        #endregion

        #region Fields

        private float _headBobTimer;
        private Camera _mainCamera;
        private CinemachineVirtualCamera _activeCamera;

        #endregion

        #region Properties

        private Camera MainCamera => _mainCamera ??= Camera.main;
        public Vector3 CameraForward => MainCamera.transform.forward;
        public Vector3 CameraRight => MainCamera.transform.right;

        private CinemachineVirtualCamera ActiveCamera
        {
            get => _activeCamera;
            set
            {
                if (_activeCamera)
                {
                    _activeCamera.Priority = PriorityLow;
                }
                
                _activeCamera = value;

                if (_activeCamera)
                {
                    _activeCamera.Priority = PriorityHigh;
                }
            }
        }

        #endregion

        #region Methods

        public void SetActiveCamera(ActiveCameraType activeCameraType)
        {
            switch (activeCameraType)
            {
                case ActiveCameraType.FreeLook:
                    ActiveCamera = _cinemachineFreeLook;
                    break;
                case ActiveCameraType.Death:
                    ActiveCamera = _cinemachineDeath;
                    break;
                default:
                    ActiveCamera = null;
                    break;
            }
        }

        public void TickHeadBob(float magnitude, float deltaTime)
        {
            if (_headBobTimer > 0f)
            {
                _headBobTimer -= deltaTime;
                return;
            }

            _headBobTimer = HeadBobDelayTime;

            if (magnitude <= 0f)
            {
                return;
            }
            
            _cinemachineImpulseSource.GenerateImpulse();
            OnFootStepped?.Invoke();
        }
        public void SetLookInputs(Vector2 inputs)
        {
            _cinemachineExtensionFirstPersonInputs.ReceiveInputs(inputs);
        }

        #endregion
    }
}