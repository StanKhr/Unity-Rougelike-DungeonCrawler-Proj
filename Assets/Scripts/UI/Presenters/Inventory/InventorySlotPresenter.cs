﻿using Miscellaneous;
using Player.Inventories.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Presenters.Inventory
{
    public class InventorySlotPresenter : MonoBehaviour, ISubmitHandler
    {
        #region Constants

        private const int DefaultSlotIndex = -1;

        #endregion
        
        #region Events

        public static event DelegateHolder.InventorySlotPresenterEvents OnUsed;

        #endregion
        
        #region Constants

        private static readonly Color IconColorFilled = new Color(1f, 1f, 1f, 1f);
        private static readonly Color IconColorEmpty = new Color(0f, 0f, 0f, 0f);

        #endregion
        
        #region Editor Fields

        [SerializeField] private Image _itemIconImage;

        #endregion

        #region Fields

        private InventorySlot _correspondingSlot;

        #endregion

        #region Properties

        public int SlotIndex { get; set; } = DefaultSlotIndex;

        #endregion

        #region Methods

        public bool TryUpdateCorrespondingSlot(InventorySlot slot)
        {
            if (_correspondingSlot == slot)
            {
                return false;
            }

            _correspondingSlot = slot;

            SetIcon(slot);

            return true;
        }

        private void SetIcon(InventorySlot slot)
        {
            if (slot.Item == null)
            {
                _itemIconImage.color = IconColorEmpty;
                return;
            }

            _itemIconImage.sprite = slot.Item.Icon;
            _itemIconImage.color = IconColorFilled;
        }

        public void OnSubmit(BaseEventData eventData)
        {
            OnUsed?.Invoke(this);
        }

        #endregion
    }
}