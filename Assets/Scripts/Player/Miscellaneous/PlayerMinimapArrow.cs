using UnityEngine;

namespace Player.Miscellaneous
{
    public class PlayerMinimapArrow : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private float _presicion = 0;

        #endregion

        #region Fields

        private Vector3 _eulersOffset;
        private Camera _camera;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _camera = Camera.main;
            _eulersOffset = transform.localEulerAngles;
        }

        private void Update()
        {
            var cameraEulers = _camera.transform.eulerAngles;
            var objectEulers = transform.localEulerAngles - _eulersOffset;
            if ((cameraEulers - objectEulers).sqrMagnitude <= _presicion)
            {
                return;
            }

            transform.localEulerAngles = cameraEulers + _eulersOffset;
        }

        #endregion
    }
}