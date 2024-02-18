using Cinemachine;
using Player.Inputs;
using Player.Inputs.Interfaces;
using UnityEngine;

namespace Player.Cameras
{
    public class CameraDirectInputProvider : MonoBehaviour, AxisState.IInputAxisProvider
    {
        #region Editor Fields

        [SerializeField] private InputProvider _inputProvider;

        #endregion

        #region Properties

        private IInputProvider InputProvider => _inputProvider;

        #endregion
        
        #region Methods

        public float GetAxisValue(int axis)
        {
            return axis switch
            {
                0 => InputProvider.MapWrapperCamera.LookInputs.x,
                1 => InputProvider.MapWrapperCamera.LookInputs.y,
                _ => 0f

            };
        }

        #endregion
    }
}