using System;
using System.Text;
using Player.Inventories.Interfaces;
using UnityEngine;
using UnityEngine.Localization;

namespace Player.Inventories.Items
{
    [Serializable]
    public abstract class Item : ScriptableObject, IItem
    {
        #region Constants

        private const string DefaultEmptyString = "...";

        #endregion
        
        #region Editor Fields

        [SerializeField, HideInInspector] private string _guid;
        [SerializeField] private Sprite _icon;
        [SerializeField] private LocalizedString _name;
        [SerializeField] private LocalizedString _description;

        #endregion

        #region Fields

        private static readonly StringBuilder StringBuilder = new();

        #endregion

        #region Properties

        public string Guid => _guid;
        public Sprite Icon => _icon;
        public virtual string Description
        {
            get
            {
                StringBuilder.Clear();
                StringBuilder.Append(!_name.IsEmpty ? _name.GetLocalizedString() : DefaultEmptyString);
                StringBuilder.Append("\n");
                StringBuilder.Append(!_description.IsEmpty ? _description.GetLocalizedString() : DefaultEmptyString);

                return StringBuilder.ToString();
            }
        }

        #endregion
    }
}