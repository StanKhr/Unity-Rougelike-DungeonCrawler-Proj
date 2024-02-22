using System;
using Miscellaneous;
using Player.Inventories;
using Player.Inventories.Interfaces;
using UnityEngine;

namespace UI.Presenters
{
    public class InventoryPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Inventory _inventory;

        #endregion

        #region Properties

        private IInventory Inventory => _inventory;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            InitializeSlots();
            
            Inventory.Slots.OnSlotUpdated += SlotUpdatedCallback;
            Inventory.OnItemDropped += ItemDroppedCallback;
        }

        private void OnDestroy()
        {
            Inventory.Slots.OnSlotUpdated -= SlotUpdatedCallback;
            Inventory.OnItemDropped -= ItemDroppedCallback;
        }

        #endregion

        #region Methods

        private void InitializeSlots()
        {
            // update all slot views according to inventory
            var slots = Inventory.Slots;
            
            for (int i = 0; i < slots.Length; i++)
            {
                LogWriter.DevelopmentLog($"Index {i.ToString()}; Slot is empty: {slots[i].IsEmpty.ToString()}; ({slots[i].Item})");
            }
        }
        
        private void SlotUpdatedCallback(int context)
        {
            // update related slot view
            LogWriter.DevelopmentLog($"Inventory slot updated: {context.ToString()}");
        }

        private void ItemDroppedCallback(IItem context)
        {
            LogWriter.DevelopmentLog($"Item: {context} was dropped from the inventory!");
        }

        #endregion
    }
}