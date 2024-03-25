using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Settings.Localization
{
    public class LocalizationSelection : MonoBehaviour
    {
        #region Methods

        public void SelectLocale(int index)
        {
            if (!LocalizationSettings.InitializationOperation.IsDone)
            {
                return;
            }

            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        } 

        #endregion
    }
}