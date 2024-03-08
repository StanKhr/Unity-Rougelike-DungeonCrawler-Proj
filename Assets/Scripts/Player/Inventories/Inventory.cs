﻿using System;
using Miscellaneous;
using Player.Inventories.Datas;
using Player.Inventories.Interfaces;
using Props.Interfaces;
using UnityEngine;

namespace Player.Inventories
{
    public class Inventory : MonoBehaviour, IInventory
    {
        #region Events
        
        public event DelegateHolder.ItemEvents OnItemAdded;
        public event DelegateHolder.ItemEvents OnItemDropped;
        public event DelegateHolder.ItemEvents OnItemUsed;

        #endregion

        #region Fields

        private readonly SlotsData _slots = new SlotsData();

        #endregion

        #region Properties
        public SlotsData Slots => _slots;

        #endregion

        #region Unity Callbacks

        [ContextMenu("Test add sword")]
        private void TestAddEquipSword()
        {
            var testGuid = "6d37904db7290ee428c658a90968e6e5";
            var item = ItemDatabase.Instance.GetFromGuid(testGuid);
            TryAdd(item as IItem);
        }

        [ContextMenu("Test use sword")]
        private void TestUnequipSword()
        {
            var testGuid = "6d37904db7290ee428c658a90968e6e5";
            var item = ItemDatabase.Instance.GetFromGuid(testGuid);
            
            if (HasItem(item, out int slotIndex))
            {
                TryUse(slotIndex);
            }
        }

        #endregion

        #region Public Methods

        public bool HasItemType(Type type, out int slotIndex)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].IsEmpty)
                {
                    continue;
                }

                if (_slots[i].Item.GetType() != type)
                {
                    continue;
                }

                slotIndex = i;
                return true;
            }

            slotIndex = 0;
            return false;
        }

        public bool HasItem(IItem item, out int slotIndex)
        {
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

            slotIndex = 0;
            return false;
        }

        public bool TryAdd(IItem item)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].IsEmpty)
                {
                    _slots.SetSlot(i, item);
                    OnItemAdded?.Invoke(item);
                    
                    return true;
                }
            }
            return false;
        }

        public bool TryDrop(IItem item)
        {
            if (!HasItem(item, out var slotIndex))
            {
                return false;
            }

            return TryDrop(slotIndex);
        }

        public bool TryDrop(int slotIndex)
        {
            if (_slots[slotIndex].IsEmpty)
            {
                return false;
            }

            var item = _slots[slotIndex].Item;
            if (!_slots.ClearSlot(slotIndex))
            {
                return false;
            }
            
            OnItemDropped?.Invoke(item);
            
            return true;
        }

        public bool TryUse(int slotIndex)
        {
            if (_slots[slotIndex].IsEmpty)
            {
                return false;
            }
            
            if (_slots[slotIndex].Item is not IUsable usable)
            {
                return false;
            }

            var item = _slots[slotIndex].Item;
            var usedSuccessfully = usable.TryUse(gameObject);

            if (!usedSuccessfully)
            {
                return false;
            }
            
            OnItemUsed?.Invoke(item);

            return true;
        }

        #endregion
    }
}