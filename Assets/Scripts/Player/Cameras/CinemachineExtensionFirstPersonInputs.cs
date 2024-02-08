using Cinemachine;
using UnityEngine;

namespace Player.Inputs
{
    public class CinemachineExtensionFirstPersonInputs : CinemachineExtension
    {
        #region Constants

        private const float ClampYValue = 89f;

        #endregion

        #region Editor Fields

        [SerializeField, Range(0f, 1f)] private float _scaleX = 1f;
        [SerializeField, Range(0f, 1f)] private float _scaleY = 1f;
        [SerializeField] private float _speed = 1f;

        #endregion
        
        #region Fields

        private Vector3 _baseRotation;
        private Vector2 _lookInputs;

        #endregion
        
        #region Methods

        public void ReceiveInputs(Vector2 lookInputs)
        {
            _lookInputs = lookInputs;
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (!vcam.Follow)
            {
                return;
            }

            if (stage != CinemachineCore.Stage.Aim)
            {
                return;
            }

            if (_baseRotation == Vector3.zero)
            {
                _baseRotation = transform.localRotation.eulerAngles;
            }

            if (_scaleX > 0f)
            {
                _baseRotation.x += _lookInputs.x * _speed * _scaleX * deltaTime;
            }

            if (_scaleY > 0f)
            {
                var yValue = _baseRotation.y - _lookInputs.y * _speed * _scaleY * deltaTime;
            
                _baseRotation.y = Mathf.Clamp(yValue, -ClampYValue, ClampYValue);
            }

            state.RawOrientation = Quaternion.Euler(_baseRotation.y, _baseRotation.x, 0f);
        }

        #endregion
    }
}