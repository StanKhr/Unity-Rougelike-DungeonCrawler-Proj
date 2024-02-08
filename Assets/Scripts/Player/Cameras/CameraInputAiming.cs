using Cinemachine;
using UnityEngine;

namespace Player.Inputs
{
    public class CameraInputAiming : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Transform _followTransform;
        [SerializeField] private CinemachineInputProvider _cinemachineInputProvider;
        [SerializeField] private AxisState _axisY;
        [SerializeField] private AxisState _axisX;

        #endregion

        #region Properties
        
        public float AxisSpeedScale { get; set; } = 1f;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _axisX.SetInputAxisProvider(0,_cinemachineInputProvider);
            _axisY.SetInputAxisProvider(1,_cinemachineInputProvider);
        }

        private void Update()
        {
            if (AxisSpeedScale <= 0f)
            {
                return;
            }

            var time = Time.deltaTime * AxisSpeedScale;
            _axisX.Update(time);
            _axisY.Update(time);

            _followTransform.eulerAngles = new Vector3(_axisY.Value, _axisX.Value, 0f);
        }

        #endregion

        #region Public Methods

        public void SetAxisStateValue(Vector2 axis)
        {
            _axisX.Value = axis.x;
            _axisY.Value = axis.y;
            // hardcoded shit
            // _axisY.Value = Mathf.Lerp(-_axisY.m_MaxValue, _axisY.m_MaxValue, axis.y);
        }

        #endregion
    }
}