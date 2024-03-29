﻿using System.Collections;
using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;

namespace Player.Inventories.Datas
{
    public class SlotsData : IEnumerable
    {
        #region Constants

        private const int InventorySize = 24;

        #endregion

        #region Events

        public event DelegateHolder.IntEvents OnSlotUpdated;

        #endregion

        #region Fields

        private readonly InventorySlot[] _slots = new InventorySlot[InventorySize];

        #endregion

        #region Indexers

        public InventorySlot this[int index]
        {
            get
            {
                if (!ValidateIndex(index))
                {
                    return InventorySlot.CreateEmptySlot();
                }

                return _slots[index];
            }
            private set
            {
                if (_slots[index] == value)
                {
                    return;
                }

                _slots[index] = value;
                OnSlotUpdated?.Invoke(index);
            }
        }

        #endregion

        #region Properties

        public int Length => _slots.Length;

        #endregion

        #region Methods

        public IEnumerator GetEnumerator()
        {
            return _slots.GetEnumerator();
        }

        public bool ClearSlot(int index)
        {
            return SetSlot(index, null);
        }

        public bool SetSlot(int index, IItem item)
        {
            if (!ValidateIndex(index))
            {
                return false;
            }

            this[index] = new InventorySlot(item);

            return true;
        }

        private bool ValidateIndex(int index)
        {
            return index is >= 0 and < InventorySize;
        }
    }

    #endregion
}