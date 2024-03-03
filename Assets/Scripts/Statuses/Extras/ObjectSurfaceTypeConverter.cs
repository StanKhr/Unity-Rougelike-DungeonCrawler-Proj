using System;
using System.Collections.Generic;
using Statuses.Enums;
using UnityEngine;

namespace Statuses.Extras
{
    public static class ObjectSurfaceTypeConverter
    {
        #region Constants

        private const string UntaggedTagString = "Untagged";

        #endregion
        
        #region Fields

        private static Dictionary<string, ObjectSurfaceType> _sortedTypes;

        #endregion

        #region Properties

        private static Dictionary<string, ObjectSurfaceType> SortedTypes
        {
            get
            {
                if (_sortedTypes != null)
                {
                    return _sortedTypes;
                }

                _sortedTypes = new();

                var enumNames = Enum.GetNames(typeof(ObjectSurfaceType));
                var enumValues = Enum.GetValues(typeof(ObjectSurfaceType));
                
                for (int i = 0; i < enumNames.Length; i++)
                {
                    _sortedTypes.TryAdd(enumNames[i], (ObjectSurfaceType) enumValues.GetValue(i));
                }

                return _sortedTypes;
            }
        }

        #endregion

        #region Methods

        public static bool TryGetFromObject(GameObject gameObject, out ObjectSurfaceType objectSurfaceType)
        {
            if (!gameObject)
            {
                objectSurfaceType = ObjectSurfaceType.None;
                return false;
            }
            
            return TryGetTypeFromTag(gameObject.tag, out objectSurfaceType);
        }

        public static bool TryGetTypeFromTag(string objectTag, out ObjectSurfaceType objectSurfaceType)
        {
            if (string.IsNullOrEmpty(objectTag))
            {
                objectSurfaceType = ObjectSurfaceType.None;
                return false;
            }

            if (objectTag.Equals(UntaggedTagString))
            {
                objectSurfaceType = ObjectSurfaceType.None;
                return false;
            }
            
            return SortedTypes.TryGetValue(objectTag, out objectSurfaceType);
        }

        #endregion
    }
}