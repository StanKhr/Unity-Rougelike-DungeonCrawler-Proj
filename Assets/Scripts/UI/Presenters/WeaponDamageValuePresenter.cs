using Miscellaneous;
using Player.Interfaces;
using Player.Inventories;
using Plugins.StanKhrEssentials.Scripts.UI;
using TMPro;
using UnityEngine;

namespace UI.Presenters
{
    public class WeaponDamageValuePresenter : MonoBehaviour
    {
        #region Constants

        private const string NoDamageString = "0";

        #endregion

        #region Editor Fields

        [SerializeField] private Gear _gear;
        [SerializeField] private TextMeshProUGUI _text;

        #endregion

        #region Properties

        private IGear Gear => _gear;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Gear.OnWeaponEquipped.AddListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.AddListener(WeaponRemovedCallback);
        }

        private void OnDestroy()
        {
            Gear.OnWeaponEquipped.RemoveListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.RemoveListener(WeaponRemovedCallback);
        }

        #endregion
        
        #region Methods

        private void WeaponEquippedCallback(EventContext.WeaponEvent context)
        {
            var averageDamage = context.Weapon.DamageValue;
            var maxDamage = averageDamage * context.Weapon.CritDamageMultiplier;
            
            var damageString = $"{averageDamage.ToString("F1")}-{maxDamage.ToString("F1")}";
            damageString = damageString.Replace(',', '.');
            
            SetValue(damageString);
        }

        private void WeaponRemovedCallback(EventContext.WeaponEvent obj)
        {
            SetValue(NoDamageString);
        }

        private void SetValue(string value)
        {
            _text.SetTextSmart(value);
        }

        #endregion
    }
}