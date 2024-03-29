﻿using System;
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

        protected static readonly StringBuilder StringBuilder = new();

        #endregion

        #region Properties

        public string Guid => _guid;
        public Sprite Icon => _icon;
        public string Name => !_name.IsEmpty ? _name.GetLocalizedString() : DefaultEmptyString;
        public string FlavorText => !_flavorText.IsEmpty ? _flavorText.GetLocalizedString() : DefaultEmptyString;
        public virtual string CombinedDescription
        {
            get
            {
                StringBuilder.Clear();
                StringBuilder.Append(Name);
                StringBuilder.Append("\n");
                StringBuilder.Append(FlavorText);

                return StringBuilder.ToString();
            }
        }

        public LocalizedString LocalizedStringName => _name;

        #endregion
    }
}