using System.Collections.Generic;
using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using UnityEngine;

namespace Player.Inventories.LootTables
{
    [CreateAssetMenu(menuName = "RPG / Loot Tables / Smart Loot Table", fileName = "LootTable_Smart_NEW")]
    public class LootTableSmart : LootTable
    {
        #region Editor Fields

        [SerializeField] private Item[] _items;

        #endregion

        #region Fields

        private readonly List<IItem> _itemsList = new();

        #endregion
        
        #region Methods

        public override IItem GetItem()
        {
            if (_itemsList.Count <= 0)
            {
                _itemsList.AddRange(_items);
            }
            
            var listIndex = Random.Range(0, _itemsList.Count);
            var item = _itemsList[listIndex];
            _itemsList.RemoveAt(listIndex);

            return item;
        }

        #endregion
    }
}