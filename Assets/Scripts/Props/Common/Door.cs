using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class Door : Usable, IInteractable
    {
        #region Events

        public IContextEvent<EventContext.GameObjectEvent> OnInteractionStarted { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();
        public IContextEvent<EventContext.GameObjectEvent> OnInteractionEnded { get; } = 
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();

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