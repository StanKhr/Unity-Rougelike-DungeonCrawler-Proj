using System.Collections.Generic;
using System.Linq;
using Miscellaneous;
using UnityEngine;

namespace Player.Inventories
{
    public abstract class ScriptableDatabase<T> where T : ScriptableObject 
    {
        #region Fields

        private Dictionary<string, T> _dictionary;

        #endregion

        #region Properties

        private Dictionary<string, T> Dictionary
        {
            get
            {
                if (_dictionary != null)
                {
                    return _dictionary;
                }

                _dictionary = new Dictionary<string, T>();
                var scriptableObjects = Resources.LoadAll<T>("");

                foreach (var scriptableObject in scriptableObjects)
                {
                    var guid = GetGuid(scriptableObject);
                    if (string.IsNullOrEmpty(guid))
                    {
                        LogWriter.DevelopmentLog($"Item Database: {scriptableObject.name}'s GUID is null", LogType.Warning);
                        continue;
                    }
                    
                    if (_dictionary.TryAdd(guid, scriptableObject))
                    {
                        continue;
                    }
                    
                    LogWriter.DevelopmentLog($"Item Database: duplicate GUID found: {scriptableObject.name}; {guid}", LogType.Warning);
                }

                return _dictionary;
            }
        }

        #endregion

        #region Methods
        
        protected abstract string GetGuid(T scriptableObject);

        public T GetFromGuid(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return Dictionary.TryGetValue(id, out var value) ? value : null;
        }

        public T[] GetAllEntries()
        {
            return Dictionary.Values.ToArray();
        }

        #endregion
    }
}