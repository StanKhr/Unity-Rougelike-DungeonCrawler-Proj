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

        [SerializeField] private bool _weaponPreference = true;
        [SerializeField] private Item[] _items;

        #endregion

        #region Fields

        private readonly List<IItem> _itemsList = new();

        #endregion
        
        #region Methods

        public override IItem GetItem(GameObject user)
        {
            if (_itemsList.Count <= 0)
            {
                _itemsList.AddRange(_items);
            }

            if (!_weaponPreference)
            {
                return FindRandomItem();
            }

            if (!user.TryGetComponent<IInventory>(out var inventory))
            {
                return FindRandomItem();
            }

            if (inventory.HasItemType(typeof(ItemWeapon), out _))
            {
                return FindRandomItem();
            }

            if (TryFindWeapon(out var weapon))
            {
                return weapon;
            }

            return FindRandomItem();
        }

        private IItem FindRandomItem()
        {
            var listIndex = Randomizer.RangeInt(0, _itemsList.Count);
            var item = _itemsList[listIndex];
            _itemsList.RemoveAt(listIndex);

            return item;
        }

        private bool TryFindWeapon(out IItem weapon)
        {
            for (int i = 0; i < _itemsList.Count; i++)
            {
                if (_itemsList[i].GetType() != typeof(ItemWeapon))
                {
                    continue;
                }

                weapon = _itemsList[i];
                _itemsList.RemoveAt(i);
                return true;
            }

            weapon = null;
            return false;
        }

        #endregion
    }
}