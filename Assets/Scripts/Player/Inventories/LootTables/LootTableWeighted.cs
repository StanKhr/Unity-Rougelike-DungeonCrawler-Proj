using System;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using Plugins.KaimiraGames;
using UnityEngine;

namespace Player.Inventories.LootTables
{
    [CreateAssetMenu(menuName = "RPG / Loot Tables / Weighted Loot Table", fileName = "LootTable_Weighted_NEW")]
    public class LootTableWeighted : LootTable
    {
        #region Types

        [Serializable]
        private struct ItemWeightData
        {
            [field: SerializeField] public Item Item { get; private set; }
            [field: SerializeField] public int Weight { get; private set; }
        }

        #endregion

        #region Editor Fields

        [SerializeField] private ItemWeightData[] _items;

        #endregion

        #region Fields

        private WeightedList<IItem> _weightedList;

        #endregion
        
        #region Methods

        public override IItem GetItem(GameObject user)
        {
            if (_items.Length == 0)
            {
                return null;
            }
            
            if (_weightedList == null)
            {
                _weightedList = new WeightedList<IItem>();
                for (int i = 0; i < _items.Length; i++)
                {
                    _weightedList.Add(_items[i].Item, _items[i].Weight);
                }
            }

            return _weightedList.Next();
        }

        #endregion
    }
}