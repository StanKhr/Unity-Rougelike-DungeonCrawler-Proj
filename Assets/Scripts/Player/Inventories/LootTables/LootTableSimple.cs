using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using UnityEngine;

namespace Player.Inventories.LootTables
{
    [CreateAssetMenu(menuName = "RPG / Loot Tables / Simple Loot Table", fileName = "LootTable_Simple_NEW")]
    public class LootTableSimple : LootTable
    {
        #region Editor Fields

        [SerializeField] private Item[] _items;

        #endregion

        #region Methods

        public override IItem GetItem(GameObject user)
        {
            return _items[Randomizer.RangeInt(0, _items.Length)];
        }

        #endregion
    }
}