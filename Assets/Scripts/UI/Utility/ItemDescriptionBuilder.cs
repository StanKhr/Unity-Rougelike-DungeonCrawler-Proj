using System.Text;
using Player.Inventories.Interfaces;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.ResourceManagement.Util;

namespace UI.Utility
{
    public class ItemDescriptionBuilder : ComponentSingleton<ItemDescriptionBuilder>
    {
        #region Constants

        private const string ErrorMessage = "NoSpecificDescriptionFound";
        private const string VariableName = "value";

        #endregion
        
        #region Editor Fields

        [Header("Weapon Locales")]
        [SerializeField] private LocalizedString _attackValueLocale; 
        [SerializeField] private LocalizedString _speedValueLocale; 

        #endregion

        #region Fields

        private static readonly StringBuilder StringBuilder = new();

        #endregion
        
        #region Methods

        public string Build(string baseDescription, IItem item)
        {
            if (item is IWeapon weapon)
            {
                StringBuilder.Clear();
                StringBuilder.Append(baseDescription);
                StringBuilder.Append("\n\n");

                var attackValue = Mathf.RoundToInt(weapon.AttackValue);
                var attackVariable = (IntVariable)_attackValueLocale[VariableName];
                attackVariable.Value = attackValue;
                
                var attackMessage = _attackValueLocale.GetLocalizedString();
                StringBuilder.Append(attackMessage);
                StringBuilder.Append("\n");

                var speedValue = Mathf.RoundToInt(weapon.SpeedValue);
                var speedVariable = (IntVariable)_speedValueLocale[VariableName];
                speedVariable.Value = speedValue;
                
                var speedMessage = _speedValueLocale.GetLocalizedString();
                StringBuilder.Append(speedMessage);
                StringBuilder.Append("\n");
                return StringBuilder.ToString();
            }
            
            return $"{ErrorMessage}: {item.GetType().Name}";
        }

        #endregion
    }
}