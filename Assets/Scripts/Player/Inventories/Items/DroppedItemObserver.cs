using System;
using Player.Inventories.Interfaces;
using Props.Common;
using UnityEngine;

namespace Player.Inventories.Items
{
    public class DroppedItemObserver : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Inventory _inventory;
        [SerializeField] private PickableItem _pickableItemPrefab;

        #endregion

        #region Properties

        private IInventory Inventory => _inventory;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Inventory.OnItemDropped += ItemDroppedCallback;
        }

        private void OnDestroy()
        {
            Inventory.OnItemDropped -= ItemDroppedCallback;
        }

        #endregion

        #region Methods

        private void ItemDroppedCallback(IItem context)
        {
            var position = transform.position;
            var instance = Instantiate(_pickableItemPrefab, position, Quaternion.identity);
            instance.OverrideItem(context);
        }

        #endregion
    }
}