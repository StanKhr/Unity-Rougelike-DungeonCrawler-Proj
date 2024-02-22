using System;
using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.Inventories.Items
{
    [Serializable]
    public abstract class Item : ScriptableObject, IItem
    {
        #region Editor Fields

        [SerializeField, HideInInspector] private string _guid;
        [SerializeField] private Sprite _icon;

        #endregion

        #region Properties

        public string Guid => _guid;
        public Sprite Icon => _icon;

        #endregion
    }
}