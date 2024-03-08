using UI.Utility;
using UnityEngine;
using WorldGeneration.Enums;
using WorldGeneration.Interfaces;

namespace WorldGeneration.Utility
{
    public class WallTile : MonoBehaviour, IWallTile
    {
        #region Editor Fields

        [SerializeField] private GameObject _right;
        [SerializeField] private GameObject _top;
        [SerializeField] private GameObject _left;
        [SerializeField] private GameObject _bot;

        #endregion
        
        #region Methods

        public void SetTile(WalkDirectionType directionType, bool state)
        {
            switch (directionType)
            {
                case WalkDirectionType.Right:
                    _right.SetActiveSmart(state);
                    break;
                case WalkDirectionType.Top:
                    _top.SetActiveSmart(state);
                    break;
                case WalkDirectionType.Left:
                    _left.SetActiveSmart(state);
                    break;
                case WalkDirectionType.Bot:
                    _bot.SetActiveSmart(state);
                    break;
            }
        }

        #endregion
    }
}