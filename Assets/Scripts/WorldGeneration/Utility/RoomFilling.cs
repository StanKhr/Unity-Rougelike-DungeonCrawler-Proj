using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WorldGeneration.Utility
{
    public class RoomFilling : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private int SizeX = 1;
        [SerializeField] private int SizeY = 1;
        [SerializeField] private bool _rotateRandomlyWhenInstanced = true;
        
        #endregion

        #region Fields

        private static readonly int[] RotationAngles = new[]
        {
            0,
            90,
            270
        };

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            if (!_rotateRandomlyWhenInstanced)
            {
                return;
            }

            var randomAngle = RotationAngles[Random.Range(0, RotationAngles.Length)];
            if (randomAngle == 0)
            {
                return;
            }
            
            transform.Rotate(0f, (float)randomAngle, 0f);
        }

        #endregion

        #region Methods

        public Vector2Int GetRoomSize()
        {
            return new Vector2Int(SizeX, SizeY);
        }

        #endregion
    }
}