using Miscellaneous;
using UnityEngine;

namespace WorldGeneration.Utility
{
    public class RoomFilling : MonoBehaviour
    {
        #region Constants

        private const float RotateAngle90 = 90f;
        private const float RotateAngle180 = 180f;
#if UNITY_EDITOR
        private const float GizmosYSize = 2f;
#endif

        #endregion

        #region Editor Fields

        [SerializeField] private int _sizeX = 1;
        [SerializeField] private int _sizeY = 1;

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
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero + new Vector3(0f, GizmosYSize, 0f),
                new Vector3(_sizeX, GizmosYSize, _sizeY) * _gizmosScale);
        }
#endif
        
        #endregion

        #region Methods

        public Vector2Int GetRoomSize()
        {
            return new Vector2Int(_sizeX, _sizeY);
        }

        public bool TryMirror()
        {
            if (!Randomizer.CoinFlip())
            {
                return false;
            }

            transform.Rotate(0f, RotateAngle180, 0f);
            
            return true;
        }

        public void Rotate()
        {
            var randomAngle = Randomizer.CoinFlip() ? RotateAngle90 : -RotateAngle90;
            transform.Rotate(0f, randomAngle, 0f);
        }

        #endregion
    }
}