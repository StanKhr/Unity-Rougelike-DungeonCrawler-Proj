using TMPro;

namespace UI.Utility
{
    public static class ViewsExtensions
    {
        #region Methods

        public static void SetTextSmart(this TextMeshProUGUI textMeshProUGUI, string text)
        {
            if (textMeshProUGUI.text.Equals(text))
            {
                return;
            }

            textMeshProUGUI.text = text;
        }

        #endregion
    }
}