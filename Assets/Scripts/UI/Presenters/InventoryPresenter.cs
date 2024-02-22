using System;
using Miscellaneous;
using Player.Inventories;
using UnityEngine;

namespace UI.Presenters
{
    public class InventoryPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Inventory _inventory;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            InitializeSlots();
            
            _inventory.Slots.OnSlotUpdated += SlotUpdatedCallback;
        }

        private void OnDestroy()
        {
            _inventory.Slots.OnSlotUpdated -= SlotUpdatedCallback;
        }

        #endregion

        #region Methods

        private void InitializeSlots()
        {
            // update all slot views according to inventory
            var slots = _inventory.Slots;
            
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

        #endregion
    }
}