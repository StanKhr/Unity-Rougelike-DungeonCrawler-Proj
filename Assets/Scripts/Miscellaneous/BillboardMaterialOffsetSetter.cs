using System;
using UnityEngine;

namespace Miscellaneous
{
    public class BillboardMaterialOffsetSetter : MonoBehaviour
    {
        #region Constants

        private static readonly int PropertyName = Shader.PropertyToID("_YOffset");
        private const float DefaultValue = 0f;
        private const float MaxAngle = 89f;
        private const float AngleScale = 1f;

        #endregion

        #region Unity Callbacks

        private void OnDisable()
        {
            SetValue(DefaultValue);
        }

        private void LateUpdate()
        {
            var propertyValue = ConvertRotationToValue();
            SetValue(propertyValue);
        }
        
        #endregion

        #region Methods

        private float ConvertRotationToValue()
        {
            var angle = transform.eulerAngles.x * AngleScale;
            var value = Mathf.InverseLerp(-MaxAngle, MaxAngle, angle);

            // converting value from 0..1 to -1..1
            return (value - 0.5f) * -2f;
        }
        
        private void SetValue(float value)
        {
            Shader.SetGlobalFloat(PropertyName, value);
        }

        #endregion
    }
}
