using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.Inventories.LootTables;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class Chest : Usable, IInteractable
    {
        #region Events

        public IContextEvent<EventContext.GameObjectEvent> OnInteractionStarted { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();
        public IContextEvent<EventContext.GameObjectEvent> OnInteractionEnded { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();

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
                OnInteractionStarted?.NotifyListeners(new EventContext.GameObjectEvent
                {
                    GameObject = user
                });
            }
            else
            {
                OnInteractionEnded?.NotifyListeners(new EventContext.GameObjectEvent
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