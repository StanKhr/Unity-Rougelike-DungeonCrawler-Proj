using System;
using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using Props.Interfaces;
using UI.Interfaces;
using UI.Utility;
using UnityEngine;

namespace Props.Common
{
    public class PickableItem : Usable, IInteractable
    {
        #region Events
        
        public event DelegateHolder.GameObjectEvents OnInteractionStarted;
        public event DelegateHolder.GameObjectEvents OnInteractionEnded;

        #endregion
        
        #region Editor Fields

        [SerializeField] private Item _itemToPickup;
        [SerializeField] private SpriteRenderer _worldSprite;
        [SerializeField] private ScanDescription _scanDescription;

        #endregion

        #region Properties

        private IItem Item { get; set; }
        private IScanDescription ScanDescription => _scanDescription;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            if (!_itemToPickup)
            {
                return;
            }
            
            if (ScanDescription.LocalizedStringExists)
            {
                return;
            }
            
            OverrideItem(_itemToPickup, false);
        }

        #endregion
        
        #region Methods

        public void OverrideItem(IItem item, bool activateGameObject = true)
        {
            Item = item;
            _worldSprite.sprite = Item.Icon;
            ScanDescription.OverrideLocalizedString(Item.LocalizedStringName);

            if (activateGameObject)
            {
                gameObject.SetActiveSmart(true);
            }
        }

        protected override bool PerformUseLogic(GameObject user)
        {
            if (!gameObject.activeSelf)
            {
                return false;
            }
            
            if (Item == null)
            {
                return false;
            }
            
            if (!user.TryGetComponent<IInventory>(out var inventory))
            {
                return false;
            }

            var itemAdded = inventory.TryAdd(Item);

            if (itemAdded)
            {
                OnInteractionStarted?.Invoke(user);
            }
            
            return itemAdded;
        }

        #endregion
    }
}