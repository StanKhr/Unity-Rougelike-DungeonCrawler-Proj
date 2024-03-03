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
        private InventorySlotPresenter _selectedSlotPresenter;

        #endregion

        #region Properties

        private IInventory Inventory => _inventory;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            InitializeSlots();
            
            InventorySlotPresenter.OnSlotSelected += SlotSlotSelectedCallback;
            InventorySlotPresenter.OnUseItemTriggered += SlotUseItemTriggeredCallback;
            Inventory.Slots.OnSlotUpdated += SlotUpdatedCallback;
            Inventory.OnItemUsed += ItemUsedCallback;
        }

        private void OnDestroy()
        {
            InventorySlotPresenter.OnSlotSelected -= SlotSlotSelectedCallback;
            InventorySlotPresenter.OnUseItemTriggered -= SlotUseItemTriggeredCallback;
            
            Inventory.Slots.OnSlotUpdated -= SlotUpdatedCallback;
            Inventory.OnItemUsed -= ItemUsedCallback;
        }

        #endregion

        #region Public Methods
        
        public void DropItem()
        {
            if (!_selectedSlotPresenter)
            {
                return;
            }

            if (!Inventory.TryDrop(_selectedSlotPresenter.SlotIndex))
            {
                return;
            }
            
            UpdateDescriptionPopup(_selectedSlotPresenter);
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

            if (_slots.Length <= 0)
            {
                return;
            }
            
            if (!_selectedSlotPresenter)
            {
                _selectedSlotPresenter = _slots[0];
                UpdateDescriptionPopup(_selectedSlotPresenter);
            }
        }
        
        private void SlotUpdatedCallback(int context)
        {
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

        private void SlotSlotSelectedCallback(InventorySlotPresenter context)
        {
            _selectedSlotPresenter = context;
            UpdateDescriptionPopup(context);
        }

        private void SlotUseItemTriggeredCallback(InventorySlotPresenter context)
        {
            Inventory.TryUse(context.SlotIndex);
        }

        private void UpdateDescriptionPopup(InventorySlotPresenter slotPresenter)
        {
            var slot = Inventory.Slots[slotPresenter.SlotIndex];
            _itemDescriptionPopup.FillDescription(slot.Item);
        }

        private void ItemUsedCallback(IItem context)
        {
            UpdateDescriptionPopup(_selectedSlotPresenter);
        }

        #endregion
    }
}