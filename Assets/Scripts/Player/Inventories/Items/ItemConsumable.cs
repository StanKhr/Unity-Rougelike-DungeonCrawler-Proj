using Player.Inventories.ConsumableEffects;
using Player.Inventories.Interfaces;
using Props.Interfaces;
using UnityEngine;

namespace Player.Inventories.Items
{
    [CreateAssetMenu (fileName = "Item_Consumable_NEW", menuName = "RPG / Items / Consumable")]
    public class ItemConsumable : Item, IUsable
    {
        #region Editor Fields

        [SerializeField] private ConsumableEffect _consumableEffectScriptable;

        #endregion

        #region Properties

        private IConsumableEffect ConsumableEffect => _consumableEffectScriptable;

        #endregion
        
        #region Methods

        public bool TryUse(GameObject user)
        {
            if (!user.TryGetComponent<IInventory>(out var inventory))
            {
                return false;
            }

            if (!inventory.HasItemOfType(this, out var slotIndex))
            {
                return false;
            }

            if (!inventory.Slots.ClearSlot(slotIndex))
            {
                return false;
            }
            
            var consumedSuccessfully = ConsumableEffect.TryConsume(user);
            if (!consumedSuccessfully)
            {
                return false;
            }
            
            return true;
        }

        #endregion
    }
}