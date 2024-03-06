using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
using Player.Inventories.LootTables;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class Chest : Usable, IInteractable
    {
        #region Events
        
        public event DelegateHolder.GameObjectEvents OnInteractionStarted;
        public event DelegateHolder.GameObjectEvents OnInteractionEnded;

        #endregion
        
        #region Editor Fields

        [SerializeField] private LootTable _lootTable;
        
        #endregion

        #region Fields

        private bool _looted;
        private bool _opened;

        #endregion

        #region Properties

        private ILootTable LootTable => _lootTable;

        #endregion
        
        #region Methods
        
        protected override bool PerformUseLogic(GameObject user)
        {
            _opened = !_opened;

            if (_opened)
            {
                OnInteractionStarted?.Invoke(user);
            }
            else
            {
                OnInteractionEnded?.Invoke(user);
            }
            
            if (_looted)
            {
                return false;
            }

            if (!user.TryGetComponent<IInventory>(out var inventory))
            {
                return false;
            }

            var lootItem = LootTable.GetItem();
            if (!inventory.TryAdd(lootItem))
            {
                return false;
            }

            _looted = true;
            
            return true;
        }

        #endregion
    }
}