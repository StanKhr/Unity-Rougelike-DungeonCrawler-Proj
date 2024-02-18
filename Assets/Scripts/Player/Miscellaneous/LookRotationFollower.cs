using System;
using Player.Inputs;
using Player.Inputs.Interfaces;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class LookRotationFollower : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private InputProvider _inputProvider;
        [SerializeField, Min(0f)] private float _followSpeed = 2f;
        [SerializeField, Min(0f)] private float _maxHorizontal = 1f;
        [SerializeField, Min(0f)] private float _maxVertical = 1f;

        #endregion

        #region Properties

        private IInputProvider InputProvider => _inputProvider;

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            var lookAxis = InputProvider.MapWrapperCamera.LookInputs;

            lookAxis.x = Mathf.Clamp(lookAxis.x, -_maxHorizontal, _maxHorizontal);
            lookAxis.y = Mathf.Clamp(lookAxis.y, -_maxVertical, _maxVertical);

            transform.localPosition = Vector3.Lerp(transform.localPosition, lookAxis,
                Time.deltaTime * _followSpeed);
        }

        #endregion
    }
}