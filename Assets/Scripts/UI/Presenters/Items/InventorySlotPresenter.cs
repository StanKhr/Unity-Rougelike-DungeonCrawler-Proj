﻿using Miscellaneous;
using Player.Inventories.Items;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Presenters.Items
{
    public class InventorySlotPresenter : MonoBehaviour, ISelectHandler, ISubmitHandler, IPointerClickHandler, IPointerEnterHandler
    {
        #region Constants

        private const int DefaultSlotIndex = -1;

        #endregion
        
        #region Events

        public static IContextEvent<EventContext.InventorySlotPresenterEvent> OnSlotSelected { get; } =
            EventFactory.CreateContextEvent<EventContext.InventorySlotPresenterEvent>();
        public static IContextEvent<EventContext.InventorySlotPresenterEvent> OnUseItemTriggered { get; } =
            EventFactory.CreateContextEvent<EventContext.InventorySlotPresenterEvent>();
        public static IContextEvent<EventContext.InventorySlotPresenterEvent> OnSlotDropped { get; } =
            EventFactory.CreateContextEvent<EventContext.InventorySlotPresenterEvent>();

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

        private EventContext.InventorySlotPresenterEvent EventContext => new()
        {
            InventorySlotPresenter = this
        };

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            if (EventSystem.current.currentSelectedGameObject != gameObject)
            {
                return;
            }
            
            OnSlotSelected?.NotifyListeners(EventContext);
        }

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
            OnUseItemTriggered?.NotifyListeners(EventContext);
        }

        public void OnSelect(BaseEventData eventData)
        {
            OnSlotSelected?.NotifyListeners(EventContext);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (EventSystem.current.currentSelectedGameObject == gameObject)
            {
                return;
            }
            
            OnSlotSelected?.NotifyListeners(EventContext);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnSlotDropped?.NotifyListeners(EventContext);
                return;
            }

            OnUseItemTriggered?.NotifyListeners(EventContext);
        }

        #endregion
    }
}