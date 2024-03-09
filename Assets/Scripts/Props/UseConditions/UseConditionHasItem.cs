using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using Props.Interfaces;
using UnityEngine;

namespace Props.UseConditions
{
    public class UseConditionHasItem : UseCondition, IUseCondition
    {
        #region Editor Fields

        [SerializeField] private Item _expectedItem;
        [SerializeField] private bool _removeItemIfTrue = false;

        #endregion

        #region Properties

        private IItem Item => _expectedItem;

        #endregion
        
        #region Methods

        public override bool Check(IUsable usable, GameObject user)
        {
            if (!_expectedItem)
            {
                return true;
            }
            
            if (!user.TryGetComponent<IInventory>(out var inventory))
            {
                return false;
            }

            if (!inventory.HasItem(Item, out var slotIndex))
            {
                return false;
            }

            if (_removeItemIfTrue)
            {
                inventory.Slots.SetSlot(slotIndex, null);
            }

            return true;
        }

        #endregion
    }
}