using TMPro;
using UI.Utility;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace UI.Presenters
{
    public class EquipmentPresenterBase : MonoBehaviour
    {
        #region Constants

        private static readonly Color ColorNormal = new Color(1f, 1f, 1f, 1f);
        private static readonly Color ColorEmpty = new Color(.5f, .5f, .5f, 1f);
        private const string VariableName = "value";

        #endregion

        #region Editor Fields

        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        [SerializeField] private LocalizedString _localizedStringValue;
        [SerializeField] private LocalizedString _localeEmpty;

        #endregion

        #region Methods

        protected void SetValue(string value)
        {
            var valueExists = !string.IsNullOrEmpty(value);
            var equipName = valueExists ? value : _localeEmpty.GetLocalizedString();
            _textMeshProUGUI.color = valueExists ? ColorNormal : ColorEmpty;
            
            var variable = (StringVariable)_localizedStringValue[VariableName];
            variable.Value = equipName;
            _textMeshProUGUI.SetTextSmart(_localizedStringValue.GetLocalizedString());
        }

        #endregion
    }
}