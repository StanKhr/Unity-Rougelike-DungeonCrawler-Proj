using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using Player.Inventories.Interfaces;
using Player.Inventories.LootTables;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class Chest : Usable, IInteractable
    {
        #region Events

        public IContextEvent<Events.GameObjectEvent> OnInteractionStarted { get; } =
            new ContextEvent<Events.GameObjectEvent>();
        public IContextEvent<Events.GameObjectEvent> OnInteractionEnded { get; } =
            new ContextEvent<Events.GameObjectEvent>();

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
                OnInteractionStarted?.NotifyListeners(new Events.GameObjectEvent
                {
                    GameObject = user
                });
            }
            else
            {
                OnInteractionEnded?.NotifyListeners(new Events.GameObjectEvent
                {
                    GameObject = user
                });
            }
            
            if (_looted)
            {
                return false;
            }

            if (!user.TryGetComponent<IInventory>(out var inventory))
            {
                return false;
            }

            var lootItem = LootTable.GetItem(user);
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