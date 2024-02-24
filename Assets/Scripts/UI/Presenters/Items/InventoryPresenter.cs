using Miscellaneous;
using Player.Inventories;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using UnityEngine;

namespace UI.Presenters.Items
{
    public class InventoryPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Inventory _inventory;
        [SerializeField] private ItemDescriptionPopup _itemDescriptionPopup;

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
            
            InventorySlotPresenter.OnSelected += SlotSelectedCallback;
            InventorySlotPresenter.OnUsed += SlotUsedCallback;
            Inventory.Slots.OnSlotUpdated += SlotUpdatedCallback;
            // Inventory.OnItemDropped += ItemDroppedCallback;
        }

        private void OnDestroy()
        {
            InventorySlotPresenter.OnSelected -= SlotSelectedCallback;
            InventorySlotPresenter.OnUsed -= SlotUsedCallback;
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
                _slots[i].SlotIndex = i;
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

        private void SlotSelectedCallback(InventorySlotPresenter context)
        {
            var slot = Inventory.Slots[context.SlotIndex];
            _itemDescriptionPopup.FillDescription(slot.Item);
        }

        private void SlotUsedCallback(InventorySlotPresenter context)
        {
            Inventory.TryUse(context.SlotIndex);
        }

        #endregion
    }
}