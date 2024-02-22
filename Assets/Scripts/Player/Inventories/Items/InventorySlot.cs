using Player.Inventories.Interfaces;

namespace Player.Inventories.Items
{
    public readonly struct InventorySlot
    {
        #region Constructors

        public InventorySlot(IItem item)
        {
            Item = item;
        }

        #endregion

        #region Properties

        public IItem Item { get; }
        public bool IsEmpty => Item == null;

        #endregion

        #region Methods

        public static InventorySlot CreateEmptySlot()
        {
            return new InventorySlot(null);
        }

        #endregion

        #region Operators

        public static bool operator ==(InventorySlot a, InventorySlot b)
        {
            return a.Item == b.Item;
        }

        public static bool operator !=(InventorySlot a, InventorySlot b)
        {
            return !(a == b);
        }

        #endregion
    }
}