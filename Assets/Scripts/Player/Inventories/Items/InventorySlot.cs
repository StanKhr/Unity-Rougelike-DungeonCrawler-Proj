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
        
        public bool Equals(InventorySlot other)
        {
            return Equals(Item, other.Item);
        }

        public override bool Equals(object obj)
        {
            return obj is InventorySlot other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Item != null ? Item.GetHashCode() : 0);
        }

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