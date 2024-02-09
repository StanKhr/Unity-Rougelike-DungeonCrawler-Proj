using Cinemachine;
using Player.Cameras.Interfaces;
using Player.Inputs;
using UnityEngine;

namespace Player.Cameras
{
    public class CameraWrapper : MonoBehaviour, ICameraWrapper
    {
        #region Constants

        private const float HeadBobDelayTime = 0.45f;

        #endregion

        #region Editor Fields

        [field: SerializeField] public CinemachineExtensionFirstPersonInputs _cinemachineExtensionFirstPersonInputs;
        [field: SerializeField] public CinemachineImpulseSource _cinemachineImpulseSource;

        #endregion

        #region Fields

        private float _headBobTimer;
        private Camera _mainCamera;

        #endregion

        #region Properties

        private Camera MainCamera => _mainCamera ??= Camera.main;
        public Vector3 CameraForward => MainCamera.transform.forward;
        public Vector3 CameraRight => MainCamera.transform.right;

        #endregion

        #region Methods

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

            // var velocity = _cinemachineImpulseSource.m_DefaultVelocity;
            // _cinemachineImpulseSource.GenerateImpulseWithVelocity(velocity);
            _cinemachineImpulseSource.GenerateImpulse();
        }
        public void SetLookInputs(Vector2 inputs)
        {
            _cinemachineExtensionFirstPersonInputs.ReceiveInputs(inputs);
        }

        #endregion
    }
}