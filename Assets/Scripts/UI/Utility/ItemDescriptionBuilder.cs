using System;
using System.Text;
using Miscellaneous;
using Player.Inventories.Enums;
using Player.Inventories.Interfaces;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.ResourceManagement.Util;

namespace UI.Utility
{
    public class ItemDescriptionBuilder : Singleton<ItemDescriptionBuilder>
    {
        #region Constants

        private const string ErrorMessage = "NoSpecificDescriptionFound";
        private const string VariableValue = "value";
        private const string VariableStrength = "str";
        private const string VariableDexterity = "dex";
        private const string VariableIntellect = "int";
        private const string AttributeNoneString = "-";

        #endregion
        
        #region Editor Fields

        [Header("Weapon Locales")]
        [SerializeField] private LocalizedString _damageValueLocale; 
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
            StringBuilder.Append(weapon.Name.GetLocalizedString());
            StringBuilder.Append("\n");
            StringBuilder.Append(weapon.FlavorText.GetLocalizedString());
            StringBuilder.Append("\n\n");

            var damageValue = Mathf.RoundToInt(weapon.DamageValue);
            var damageVariable = (IntVariable)_damageValueLocale[VariableValue];
            damageVariable.Value = damageValue;
                
            var attackMessage = _damageValueLocale.GetLocalizedString();
            StringBuilder.Append(attackMessage);
            StringBuilder.Append("\n");

            var speedValue = Mathf.RoundToInt(weapon.SpeedValue);
            var speedVariable = (IntVariable)_speedValueLocale[VariableValue];
            speedVariable.Value = speedValue;
                
            var speedMessage = _speedValueLocale.GetLocalizedString();
            StringBuilder.Append(speedMessage);
            StringBuilder.Append("\n");

            var strName = GetAttributeScaleName(weapon.ScaleStrength);
            var dexName = GetAttributeScaleName(weapon.ScaleDexterity);
            var intName = GetAttributeScaleName(weapon.ScaleIntellect);

            var strVariable = (StringVariable) _attributesScaleLocale[VariableStrength];
            var dexVariable = (StringVariable) _attributesScaleLocale[VariableDexterity];
            var intVariable = (StringVariable) _attributesScaleLocale[VariableIntellect];

            strVariable.Value = strName;
            dexVariable.Value = dexName;
            intVariable.Value = intName;

            StringBuilder.Append(_attributesScaleLocale.GetLocalizedString());
            
            return StringBuilder.ToString();
        }

        private string GetAttributeScaleName(AttributeScaleType attributeScaleType)
        {
            if (attributeScaleType == AttributeScaleType.None)
            {
                return AttributeNoneString;
            }
            
            var attributeType = typeof(AttributeScaleType);
            return Enum.GetName(attributeType, attributeScaleType);
        }

        #endregion
    }
}