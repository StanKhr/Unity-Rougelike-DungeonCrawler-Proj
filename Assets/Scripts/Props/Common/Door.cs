using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class Door : Usable, IInteractable
    {
        #region Events

        public IContextEvent<Events.GameObjectEvent> OnInteractionStarted { get; } =
            new ContextEvent<Events.GameObjectEvent>();
        public IContextEvent<Events.GameObjectEvent> OnInteractionEnded { get; } =
            new ContextEvent<Events.GameObjectEvent>();

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
                    OnInteractionStarted?.NotifyListeners(default);
                    return;
                }
                
                OnInteractionEnded?.NotifyListeners(default);
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