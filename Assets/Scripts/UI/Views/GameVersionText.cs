using Plugins.StanKhrEssentials.Scripts.UI;
using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class GameVersionText : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private TextMeshProUGUI _text;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _text.SetTextSmart($"Build {Application.version}");
        }

        #endregion
    }
}