using System;
using Miscellaneous;
using Player.Inventories.Datas;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;

namespace Player.Inventories.Interfaces
{
    public interface IInventory
    {
        #region Events
        
        IContextEvent<EventContext.ItemEvent> OnItemAdded { get; }
        IContextEvent<EventContext.ItemEvent> OnItemDropped { get; }
        IContextEvent<EventContext.ItemEvent> OnItemUsed { get; }

        #endregion
        
        #region Properties

        SlotsData Slots { get; }
        bool ItemManipulationsEnabled { get; set; }

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