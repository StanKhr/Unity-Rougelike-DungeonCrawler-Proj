using System;
using System.Collections.Generic;
using System.Threading;
using Plugins.StanKhrEssentials.Scripts.UI.Views;
using Settings.Localization;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace UI.Presenters
{
    public class LocalizationSelectionPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private LocalizationSelection _localizationSelection;
        
        [Header("Views")]
        [SerializeField] private OptionSelector _optionSelector;

        #endregion

        #region Unity Callbacks

        private async void Start()
        {
            // await LocalizationSettings.
            // var options = 
            var locales = LocalizationSettings.AvailableLocales.Locales;
            var options = new List<string>(locales.Count);
            for (int i = 0; i < locales.Count; i++)
            {
                options.Add(locales[i].LocaleName);
            }
            
            _optionSelector.OverrideOptions(options);

            _optionSelector.OnSelectedOptionUpdated.AddListener(SelectedOptionUpdatedCallback);
        }

        private void OnDestroy()
        {
            _optionSelector.OnSelectedOptionUpdated.RemoveListener(SelectedOptionUpdatedCallback);
        }

        #endregion

        #region Methods
        
        private void SelectedOptionUpdatedCallback()
        {
            var selectedOptionIndex = _optionSelector.SelectedOptionIndex;
            _localizationSelection.SelectLocale(selectedOptionIndex);
        }

        #endregion
    }
}