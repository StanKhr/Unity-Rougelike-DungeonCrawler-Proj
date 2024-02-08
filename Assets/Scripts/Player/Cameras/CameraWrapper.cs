using Player.Cameras.Interfaces;
using Player.Inputs.Interfaces;
using UnityEngine;

namespace Player.Inputs
{
    public class CameraWrapper : MonoBehaviour, ICameraWrapper
    {
        #region Editor Fields

        [field: SerializeField] public CinemachineExtensionFirstPersonInputs _cinemachineExtensionFirstPersonInputs;

        #endregion

        #region Fields

        private Camera _mainCamera;

        #endregion

        #region Properties

        private Camera MainCamera => _mainCamera ??= Camera.main;
        public Vector3 CameraForward => MainCamera.transform.forward;
        public Vector3 CameraRight => MainCamera.transform.right;

        #endregion

        #region Methods

        public void SetLookInputs(Vector2 inputs)
        {
            _cinemachineExtensionFirstPersonInputs.ReceiveInputs(inputs);
        }

        #endregion
    }
}