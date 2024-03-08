using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using UnityEngine;

namespace Player.Inventories.LootTables
{
    [CreateAssetMenu(menuName = "RPG / Loot Tables / Single Item Loot Table", fileName = "LootTable_SingleItem_NEW")]
    public class LootTableSingleItem : LootTable
    {
        #region MyRegion

        [SerializeField] private Item _item;

        #endregion
        
        #region Methods

        public override IItem GetItem(GameObject user)
        {
            return _item;
        }

        #endregion
    }
}