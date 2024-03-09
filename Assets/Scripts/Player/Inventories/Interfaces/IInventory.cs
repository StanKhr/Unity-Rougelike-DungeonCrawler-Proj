using System;
using Miscellaneous;
using Player.Inventories.Datas;

namespace Player.Inventories.Interfaces
{
    public interface IInventory
    {
        #region Events
        
        event DelegateHolder.ItemEvents OnItemAdded;
        event DelegateHolder.ItemEvents OnItemDropped;
        event DelegateHolder.ItemEvents OnItemUsed;

        #endregion
        
        #region Properties

        SlotsData Slots { get; }

        #endregion
        
        #region Methods

        bool HasItemType(Type type, out int slotIndex);
        bool HasItem(IItem item, out int slotIndex);
        bool TryAdd(IItem item);
        bool TryDrop(IItem item);
        bool TryDrop(int slotIndex);
        bool TryUse(int slotIndex);

        #endregion
    }
}