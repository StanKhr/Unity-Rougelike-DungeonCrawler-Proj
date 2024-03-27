using Miscellaneous;
using Player.Interfaces;
using Player.Inventories;
using Player.Inventories.Interfaces;
using Plugins.StanKhrEssentials.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace UI.Presenters
{
    public class WeaponNamePresenter : MonoBehaviour
    {
        #region Constants

        private static readonly Color ColorNormal = new Color(1f, 1f, 1f, 1f);
        private static readonly Color ColorEmpty = new Color(.5f, .5f, .5f, 1f);
        private const string VariableName = "value";

        #endregion

        #region Editor Fields

        [SerializeField] private Gear _gear;
        [SerializeField] private LocalizedString _localizedStringValue;
        [SerializeField] private LocalizedString _localeEmpty;
        [SerializeField] private TextMeshProUGUI _text;
        
        #endregion

        #region Fields

        private IWeapon _usedWeapon;

        #endregion

        #region Properties

        private IGear Gear => _gear;
        private IWeapon UsedWeapon
        {
            get => _usedWeapon;
            set
            {
                _usedWeapon = value;
                UpdateLocale();
            }
        }

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            LocalizationSettings.SelectedLocaleChanged += SelectedLocaleChangedCallback;

            Gear.OnWeaponEquipped.AddListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.AddListener(WeaponRemovedCallback);
        }

        private void OnDisable()
        {
            LocalizationSettings.SelectedLocaleChanged -= SelectedLocaleChangedCallback;

            Gear.OnWeaponEquipped.RemoveListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.RemoveListener(WeaponRemovedCallback);
        }

        #endregion

        #region Methods

        private void SelectedLocaleChangedCallback(Locale obj)
        {
            UpdateLocale();
        }

        private void WeaponEquippedCallback(EventContext.WeaponEvent context)
        {
            UsedWeapon = context.Weapon;
        }

        private void WeaponRemovedCallback(EventContext.WeaponEvent context)
        {
            UsedWeapon = null;
        }

        private void UpdateLocale()
        {
            SetValue(UsedWeapon != null
                ? UsedWeapon.LocalizedStringName.GetLocalizedString()
                : _localeEmpty.GetLocalizedString());
            _text.SetColorSmart(UsedWeapon != null ? ColorNormal : ColorEmpty);
        }

        private void SetValue(string value)
        {
            var variable = (StringVariable) _localizedStringValue[VariableName];
            variable.Value = value;
            
            _text.SetTextSmart(_localizedStringValue.GetLocalizedString());
        }

        #endregion
    }
}