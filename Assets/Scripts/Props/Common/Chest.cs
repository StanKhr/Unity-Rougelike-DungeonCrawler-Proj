using Miscellaneous;
using Player.Inventories.Interfaces;
using Player.Inventories.Items;
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

        [SerializeField] private Item _item;

        #endregion

        #region Fields

        private bool _looted;
        private bool _opened;

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

            if (!inventory.TryAdd(_item))
            {
                return false;
            }

            _looted = true;
            
            return true;
        }

        #endregion
    }
}