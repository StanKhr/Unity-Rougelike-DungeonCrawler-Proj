using Miscellaneous;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class Door : Usable, IInteractable
    {
        #region Events
        
        public event DelegateHolder.GameObjectEvents OnInteractionStarted;
        public event DelegateHolder.GameObjectEvents OnInteractionEnded;

        #endregion

        #region Fields

        private bool _opened;

        #endregion

        #region Properties
        
        private bool Opened
        {
            get => _opened;
            set
            {
                if (Opened == value)
                {
                    return;
                }
                
                _opened = value;

                if (Opened)
                {
                    OnInteractionStarted?.Invoke(null);
                    return;
                }
                
                OnInteractionEnded?.Invoke(null);
            }
        }

        #endregion

        #region Methods

        protected override bool PerformUseLogic(GameObject user)
        {
            Opened = !Opened;
            return true;
        }

        #endregion
    }
}