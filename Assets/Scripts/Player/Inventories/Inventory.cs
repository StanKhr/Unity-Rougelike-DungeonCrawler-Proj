using System;
using System.Linq;
using Miscellaneous;
using Player.Interfaces;
using Player.Inventories.Datas;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using UnityEngine;

namespace Player.Inventories
{
    public class Inventory : MonoBehaviour, IInventory
    {
        #region Constants

        #endregion

        #region Fields

        private readonly SlotsData _slots = new SlotsData();

        #endregion

        #region Properties

        public SlotsData Slots => _slots;

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
                    _slots.SetSlot(i, item);
                    return true;
                }
            }
            return false;
        }

        public bool TryDrop(IItem item)
        {
            if (!HasItemOfType(item, out var slotIndex))
            {
                return false;
            }
            
            _slots.SetSlot(slotIndex, null);

            return true;
        }

        public bool TryDrop(int slotIndex)
        {
            return false;
        }

        #endregion
    }
}