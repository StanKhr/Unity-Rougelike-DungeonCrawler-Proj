using System;
using Miscellaneous;
using Player.Inventories.Datas;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;

namespace Player.Inventories.Interfaces
{
    public interface IInventory
    {
        #region Events
        
        IContextEvent<Events.ItemEvent> OnItemAdded { get; }
        IContextEvent<Events.ItemEvent> OnItemDropped { get; }
        IContextEvent<Events.ItemEvent> OnItemUsed { get; }

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