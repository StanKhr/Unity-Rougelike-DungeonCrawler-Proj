using System;
using System.Collections.Generic;
using Miscellaneous;
using UnityEngine;

namespace WorldGeneration.Utility
{
    public class RoomFilling : MonoBehaviour
    {
        #region Constants

#if UNITY_EDITOR
        private const float GizmosYSize = 4f;
#endif

        #endregion

        #region Editor Fields

        [SerializeField] private int _sizeX = 1;
        [SerializeField] private int _sizeY = 1;
        [SerializeField] private List<float> _rotationAngles;

#if UNITY_EDITOR
        [SerializeField] private int _gizmosScale = 2;
#endif

        #endregion

        #region Fields

        #endregion

        #region Unity Callbacks

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + new Vector3(0f, GizmosYSize, 0f),
                new Vector3(_sizeX, GizmosYSize, _sizeY) * _gizmosScale);
        }
#endif

        private void Start()
        {
            if (_rotationAngles.Count <= 0)
            {
                return;
            }

            if (!_rotationAngles.Contains(0f))
            {
                _rotationAngles.Add(0f);
            }

            var randomAngle = _rotationAngles[Randomizer.RangeInt(0, _rotationAngles.Count)];
            if (randomAngle == 0)
            {
                return;
            }

            transform.Rotate(0f, (float) randomAngle, 0f);
        }

        #endregion

        #region Methods

        public Vector2Int GetRoomSize()
        {
            return new Vector2Int(_sizeX, _sizeY);
        }

        #endregion
    }
}