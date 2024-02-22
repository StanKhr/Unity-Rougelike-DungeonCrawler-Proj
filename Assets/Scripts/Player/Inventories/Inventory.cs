using System;
using System.Linq;
using Miscellaneous;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using UnityEngine;

namespace Player.Inventories
{
    public class Inventory : MonoBehaviour, IInventory
    {
        #region Constants

        private const int InventorySize = 24;

        #endregion

        #region Fields

        private readonly InventorySlot[] _slots = new InventorySlot[InventorySize];

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            TestMethod();
        }

        private void TestMethod()
        {
            var testGuid = "6d37904db7290ee428c658a90968e6e5";
            var item = ItemDatabase.Instance.GetFromGuid(testGuid);
            TryAdd(item as IItem);
            
            _slots.ToList().ForEach(slot => LogWriter.DevelopmentLog($"Slot's item: {slot.Item}"));
        }

        #endregion

        #region Public Methods

        public bool HasItemOfType(IItem item, out int slotIndex)
        {
            slotIndex = 0;
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].IsEmpty)
                {
                    continue;
                }

                if (_slots[i].Item != item)
                {
                    continue;
                }

                slotIndex = i;
                return true;
            }

            return false;
        }

        public bool TryAdd(IItem item)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].IsEmpty)
                {
                    SetSlot(i, item);
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Methods
        
        private void SetSlot(int index, IItem item)
        {
            if (!ValidateSlotIndex(index))
            {
                LogWriter.DevelopmentLog($"Slot index is invalid: {index.ToString()}", LogType.Warning, gameObject);
                return;
            }
            
            _slots[index] = new InventorySlot(item);
        }

        private bool ValidateSlotIndex(int index)
        {
            return index is >= 0 and < InventorySize;
        }

        #endregion
    }
}