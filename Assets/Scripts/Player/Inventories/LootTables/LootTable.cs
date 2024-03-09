using System;
using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.Inventories.LootTables
{
    [Serializable]
    public abstract class LootTable : ScriptableObject, ILootTable
    {
        #region Methods

        public abstract IItem GetItem(GameObject user);

        #endregion
    }
}