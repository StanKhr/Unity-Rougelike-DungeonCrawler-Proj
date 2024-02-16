using System;
using System.Text;
using Player.Miscellaneous;
using TMPro;
using UnityEngine;

namespace UI.Presenters
{
    public class PlayerGpsPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private PlayerGps _playerGps;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        #endregion

        #region Fields

        private static readonly StringBuilder StringBuilder = new();

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            StringBuilder.Clear();
            StringBuilder.Append("x: ");
            StringBuilder.Append(_playerGps.X.ToString("F0"));
            StringBuilder.Append(" y: ");
            StringBuilder.Append(_playerGps.Y.ToString("F0"));
            StringBuilder.Append(" z: ");
            StringBuilder.Append(_playerGps.Z.ToString("F0"));

            _textMeshProUGUI.text = StringBuilder.ToString();
        }

        #endregion
    }
}