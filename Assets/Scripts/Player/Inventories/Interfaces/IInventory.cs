namespace Player.Inventories.Interfaces
{
    public interface IInventory
    {
        #region Methods

        bool HasItemOfType(IItem item, out int slotIndex);
        bool TryAdd(IItem item);

        #endregion
    }
}