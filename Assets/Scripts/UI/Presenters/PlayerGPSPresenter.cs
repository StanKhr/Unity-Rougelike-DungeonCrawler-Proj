using System.Text;
using Player.Interfaces;
using Player.Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.UI;
using TMPro;
using UnityEngine;

namespace UI.Presenters
{
    public class PlayerGpsPresenter : MonoBehaviour
    {
        #region Constants

        private const string PrefixX = "x: ";
        private const string PrefixY = " y: ";
        private const string PrefixZ = " z: ";

        #endregion
        
        #region Editor Fields

        [SerializeField] private PlayerGps _playerGps;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        #endregion

        #region Fields

        private static readonly StringBuilder StringBuilder = new();
        private Vector3Int _savedPosition;

        #endregion

        #region Properties

        private IPlayerGps PlayerGps => _playerGps;

        #endregion
        
        #region Unity Callbacks

        private void Update()
        {
            var newPosition = PlayerGps.PositionRoundedToInt;
            newPosition.y = 0;
            if ((_savedPosition - newPosition).sqrMagnitude <= 0f)
            {
                return;
            }

            _savedPosition = newPosition;
            
            StringBuilder.Clear();
            StringBuilder.Append(PrefixX);
            StringBuilder.Append(_savedPosition.x.ToString("00"));
            // StringBuilder.Append(PrefixY);
            // StringBuilder.Append(_savedPosition.y.ToString("00"));
            StringBuilder.Append(PrefixY);
            StringBuilder.Append(_savedPosition.z.ToString("00"));
            
            _textMeshProUGUI.SetTextSmart(StringBuilder.ToString());
        }

        #endregion
    }
}