using TMPro;

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

        #endregion
    }
}