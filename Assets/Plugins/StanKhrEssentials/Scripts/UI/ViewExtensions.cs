using TMPro;
using UnityEngine;

namespace Plugins.StanKhrEssentials.Scripts.UI
{
    public static class ViewExtensions
    {
        #region Methods

        public static void SetTextSmart(this TextMeshProUGUI textMeshProUGUI, string text)
        {
            if (textMeshProUGUI.text.Equals(text))
            {
                return;
            }

            textMeshProUGUI.text = text ?? string.Empty;
        }
        
        public static void SetColorSmart(this TextMeshProUGUI textMeshProUGUI, Color color)
        {
            if (textMeshProUGUI.color.Equals(color))
            {
                return;
            }

            textMeshProUGUI.color = color;
        }

        #endregion
    }
}