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
        [SerializeField] private LocalizedString _flavorText;

        #endregion

        #region Fields

        private static readonly StringBuilder StringBuilder = new();

        #endregion

        #region Properties

        public string Guid => _guid;
        public Sprite Icon => _icon;
        public LocalizedString Name => _name;
        public LocalizedString FlavorText => _flavorText;
        public virtual string CombinedDescription
        {
            get
            {
                StringBuilder.Clear();
                StringBuilder.Append(!Name.IsEmpty ? Name.GetLocalizedString() : DefaultEmptyString);
                StringBuilder.Append("\n");
                StringBuilder.Append(!FlavorText.IsEmpty ? FlavorText.GetLocalizedString() : DefaultEmptyString);

                return StringBuilder.ToString();
            }
        }

        #endregion
    }
}