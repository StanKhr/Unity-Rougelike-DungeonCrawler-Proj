using System;
using System.Collections.Generic;
using Statuses.Enums;

namespace Statuses.Extras
{
    public static class ObjectTagDefenceTypeConverter
    {
        #region Constants

        private const string UntaggedTagString = "Untagged";

        #endregion
        
        #region Fields

        private static Dictionary<string, DefenceType> _sortedTypes;

        #endregion

        #region Properties

        private static Dictionary<string, DefenceType> SortedTypes
        {
            get
            {
                if (_sortedTypes != null)
                {
                    return _sortedTypes;
                }

                _sortedTypes = new();

                var enumNames = Enum.GetNames(typeof(DefenceType));
                var enumValues = Enum.GetValues(typeof(DefenceType));
                
                for (int i = 0; i < enumNames.Length; i++)
                {
                    _sortedTypes.TryAdd(enumNames[i], (DefenceType) enumValues.GetValue(i));
                }

                return _sortedTypes;
            }
        }

        #endregion

        #region Methods

        public static bool TryConvertTagToDefenceType(string objectTag, out DefenceType defenceType)
        {
            if (string.IsNullOrEmpty(objectTag))
            {
                defenceType = DefenceType.None;
                return false;
            }

            if (objectTag.Equals(UntaggedTagString))
            {
                defenceType = DefenceType.None;
                return false;
            }
            
            return SortedTypes.TryGetValue(objectTag, out defenceType);
        }

        #endregion
    }
}