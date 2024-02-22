using Miscellaneous;
using Player.Inventories.Datas;

namespace Player.Inventories.Interfaces
{
    public interface IInventory
    {
        #region Properties

        SlotsData Slots { get; }

        #endregion
        
        #region Methods

        bool HasItemOfType(IItem item, out int slotIndex);
        bool TryAdd(IItem item);
        bool TryDrop(IItem item);
        bool TryDrop(int slotIndex);

        #endregion
    }
}