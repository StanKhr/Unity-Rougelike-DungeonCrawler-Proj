using System;
using Miscellaneous.Interfaces;
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
        [SerializeField] private float _throwForce = 100;

        #endregion

        #region Fields

        private Camera _camera;

        #endregion
        
        #region Properties

        private IInventory Inventory => _inventory;
        private Camera MainCamera => _camera ??= Camera.main;

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

            if (!instance.TryGetComponent<IForceApplier>(out var forceApplier))
            {
                return;
            }

            var cameraForward = MainCamera.transform.forward;
            cameraForward.y = 0f;
            cameraForward.Normalize();
            
            forceApplier.ApplyForce(cameraForward * _throwForce);
        }

        #endregion
    }
}