using System;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player.Inventories.LootTables
{
    [CreateAssetMenu(menuName = "RPG / Loot Tables / Simple Loop Table", fileName = "LoopTable_Simple_NEW")]
    public class LootTableSimple : LootTable
    {
        #region Editor Fields

        [SerializeField] private Item[] _items;

        #endregion

        #region Methods

        public override IItem GetItem()
        {
            return _items[Random.Range(0, _items.Length)];
        }

        #endregion
    }
}