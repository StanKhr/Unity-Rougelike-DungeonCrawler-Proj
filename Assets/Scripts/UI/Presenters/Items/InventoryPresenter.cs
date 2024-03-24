
using Miscellaneous;
using Player.Inventories;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using Plugins.StanKhrEssentials.EventWrapper.Main;
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
            
            InventorySlotPresenter.OnSlotSelected.AddListener(SlotSlotSelectedCallback);
            InventorySlotPresenter.OnUseItemTriggered.AddListener(SlotUseItemTriggeredCallback);
            InventorySlotPresenter.OnSlotDropped.AddListener(SlotDroppedCallback);
            
            Inventory.Slots.OnSlotUpdated.AddListener(SlotUpdatedCallback);
            Inventory.OnItemUsed.AddListener(ItemUsedCallback);
        }

        private void OnDestroy()
        {
            InventorySlotPresenter.OnSlotSelected.RemoveListener(SlotSlotSelectedCallback);
            InventorySlotPresenter.OnUseItemTriggered.RemoveListener(SlotUseItemTriggeredCallback);
            InventorySlotPresenter.OnSlotDropped.RemoveListener(SlotDroppedCallback);
            
            Inventory.Slots.OnSlotUpdated.RemoveListener(SlotUpdatedCallback);
            Inventory.OnItemUsed.RemoveListener(ItemUsedCallback);
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

        private void SlotDroppedCallback(Events.InventorySlotPresenterEvent context)
        {
            _selectedSlotPresenter = context.InventorySlotPresenter;
            DropItem();
        }
        
        private void SlotUpdatedCallback(Events.IntEvent context)
        {
            var slot = Inventory.Slots[context.Int];
            FillSlotPresenter(context.Int, slot);
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

        private void SlotSlotSelectedCallback(Events.InventorySlotPresenterEvent context)
        {
            _selectedSlotPresenter = context.InventorySlotPresenter;
            UpdateDescriptionPopup(context.InventorySlotPresenter);
        }

        private void SlotUseItemTriggeredCallback(Events.InventorySlotPresenterEvent context)
        {
            Inventory.TryUse(context.InventorySlotPresenter.SlotIndex);
        }

        private void UpdateDescriptionPopup(InventorySlotPresenter slotPresenter)
        {
            var slot = Inventory.Slots[slotPresenter.SlotIndex];
            _itemDescriptionPopup.FillDescription(slot.Item);
        }

        private void ItemUsedCallback(Events.ItemEvent context)
        {
            UpdateDescriptionPopup(_selectedSlotPresenter);
        }

        #endregion
    }
}