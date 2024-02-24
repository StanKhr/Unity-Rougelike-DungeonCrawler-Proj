using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class PickableItem : MonoBehaviour, IInteractable, IUsable
    {
        #region Events
        
        public event DelegateHolder.GameObjectEvents OnInteractionStarted;
        public event DelegateHolder.GameObjectEvents OnInteractionEnded;

        #endregion
        
        #region Editor Fields

        [SerializeField] private Item _itemToPickup;

        #endregion
        
        #region Methods

        public bool TryUse(GameObject user)
        {
            if (!gameObject.activeSelf)
            {
                return false;
            }
            
            if (!_itemToPickup)
            {
                return false;
            }

            if (TryGetComponent<IUseCondition>(out var useCondition))
            {
                if (!useCondition.Check(this, user))
                {
                    return false;
                }
            }
            
            if (!user.TryGetComponent<IInventory>(out var inventory))
            {
                return false;
            }

            var itemAdded = inventory.TryAdd(_itemToPickup);

            if (itemAdded)
            {
                OnInteractionStarted?.Invoke(user);
            }
            
            return itemAdded;
        }

        #endregion
    }
}