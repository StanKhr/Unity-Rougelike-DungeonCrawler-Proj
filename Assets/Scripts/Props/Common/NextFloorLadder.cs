using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using Props.Interfaces;
using Statuses.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class NextFloorLadder : Usable, IInteractable
    {
        #region Events

        public static IEvent OnNextFloorTriggered { get; } = EventFactory.CreateEvent();
        public IContextEvent<EventContext.GameObjectEvent> OnInteractionStarted { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();
        public IContextEvent<EventContext.GameObjectEvent> OnInteractionEnded { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();

        #endregion

        #region Methods

        protected override bool PerformUseLogic(GameObject user)
        {
            if (!user.TryGetComponent<IHealth>(out var health))
            {
                return false;
            }

            if (!health.Alive)
            {
                return false;
            }
            
            OnNextFloorTriggered?.NotifyListeners();
            return true;
        }

        #endregion
    }
}