using System;
using System.Text;
using Player.Inventories.Enums;
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
        private const string VariableValue = "value";
        private const string VariableStrength = "str";
        private const string VariableDexterity = "dex";
        private const string VariableIntellect = "int";

        #endregion
        
        #region Editor Fields

        [Header("Weapon Locales")]
        [SerializeField] private LocalizedString _attackValueLocale; 
        [SerializeField] private LocalizedString _speedValueLocale; 
        [SerializeField] private LocalizedString _attributesScaleLocale; 

        #endregion

        #region Fields

        private static readonly StringBuilder StringBuilder = new();

        #endregion
        
        #region Methods

        public string Build(IItem item)
        {
            if (item is IWeapon weapon)
            {
                return BuildWeaponDescription(weapon);
            }
            
            return $"{ErrorMessage}: {item.GetType().Name}";
        }

        private string BuildWeaponDescription(IWeapon weapon)
        {
            StringBuilder.Clear();
            StringBuilder.Append(weapon.Name);
            StringBuilder.Append("\n");
            StringBuilder.Append(weapon.FlavorText);
            StringBuilder.Append("\n\n");

            var attackValue = Mathf.RoundToInt(weapon.AttackValue);
            var attackVariable = (IntVariable)_attackValueLocale[VariableValue];
            attackVariable.Value = attackValue;
                
            var attackMessage = _attackValueLocale.GetLocalizedString();
            StringBuilder.Append(attackMessage);
            StringBuilder.Append("\n");

            var speedValue = Mathf.RoundToInt(weapon.SpeedValue);
            var speedVariable = (IntVariable)_speedValueLocale[VariableValue];
            speedVariable.Value = speedValue;
                
            var speedMessage = _speedValueLocale.GetLocalizedString();
            StringBuilder.Append(speedMessage);
            StringBuilder.Append("\n");

            var strName = Enum.GetName(typeof(AttributeScaleType), weapon.ScaleStrength);
            var dexName = Enum.GetName(typeof(AttributeScaleType), weapon.ScaleDexterity);
            var intName = Enum.GetName(typeof(AttributeScaleType), weapon.ScaleIntellect);

            var strVariable = (StringVariable) _attributesScaleLocale[VariableStrength];
            var dexVariable = (StringVariable) _attributesScaleLocale[VariableDexterity];
            var intVariable = (StringVariable) _attributesScaleLocale[VariableIntellect];

            strVariable.Value = strName;
            dexVariable.Value = dexName;
            intVariable.Value = intName;

            StringBuilder.Append(_attributesScaleLocale.GetLocalizedString());
            
            return StringBuilder.ToString();
        }

        #endregion
    }
}