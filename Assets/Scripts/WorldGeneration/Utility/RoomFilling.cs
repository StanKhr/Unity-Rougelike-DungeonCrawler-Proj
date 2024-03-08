using UnityEngine;

namespace WorldGeneration.Utility
{
    public class RoomFilling : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private int SizeX = 1;
        [SerializeField] private int SizeY = 1;
        
        #endregion

        #region Methods

        public Vector2Int GetRoomSize()
        {
            return new Vector2Int(SizeX, SizeY);
        }

        #endregion
    }
}