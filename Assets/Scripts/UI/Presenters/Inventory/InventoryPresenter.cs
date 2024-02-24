using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using UnityEngine;

namespace UI.Presenters.Inventory
{
    public class InventoryPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Player.Inventories.Inventory _inventory;

        #endregion

        #region Fields

        private InventorySlotPresenter[] _slots;

        #endregion

        #region Properties

        private IInventory Inventory => _inventory;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            InitializeSlots();
            
            Inventory.Slots.OnSlotUpdated += SlotUpdatedCallback;
            // Inventory.OnItemDropped += ItemDroppedCallback;
        }

        private void OnDestroy()
        {
            Inventory.Slots.OnSlotUpdated -= SlotUpdatedCallback;
            // Inventory.OnItemDropped -= ItemDroppedCallback;
        }

        #endregion

        #region Methods

        private void InitializeSlots()
        {
            _slots = GetComponentsInChildren<InventorySlotPresenter>();

            for (int i = 0; i < _slots.Length; i++)
            {
                var slot = Inventory.Slots[i];
                FillSlotPresenter(i, slot);
            }
        }
        
        private void SlotUpdatedCallback(int context)
        {
            // update related slot view

            var slot = Inventory.Slots[context];
            FillSlotPresenter(context, slot);
        }

        private void FillSlotPresenter(int slotIndex, InventorySlot slot)
        {
            if (slotIndex < 0 || slotIndex >= _slots.Length)
            {
                LogWriter.DevelopmentLog($"There are no slot presenter for this slot index: {slotIndex.ToString()}");
                return;
            }
            
            _slots[slotIndex].TryUpdateCorrespondingSlot(slot);
        }

        // private void ItemDroppedCallback(IItem context)
        // {
        //     LogWriter.DevelopmentLog($"Item: {context} was dropped from the inventory!");
        // }

        #endregion
    }
}