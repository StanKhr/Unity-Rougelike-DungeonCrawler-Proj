using System;
using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using Props.Interfaces;
using Statuses.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class NextFloorLadder : Usable, IInteractable
    {
        #region Events

        public static IEvent OnNextFloorTriggered { get; } = new CustomEvent();

        public IContextEvent<Events.GameObjectEvent> OnInteractionStarted { get; } =
            new ContextEvent<Events.GameObjectEvent>();

        public IContextEvent<Events.GameObjectEvent> OnInteractionEnded { get; } =
            new ContextEvent<Events.GameObjectEvent>();

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