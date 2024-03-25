using Abilities.Interfaces;
using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using UnityEngine;

namespace Abilities.Triggers
{
    public class ColliderTrigger : MonoBehaviour, IColliderTrigger
    {
        #region Events

        public IContextEvent<EventContext.ColliderEvent> OnEntered { get; } =
            EventFactory.CreateContextEvent<EventContext.ColliderEvent>();
        public IContextEvent<EventContext.ColliderEvent> OnLeft { get; } =
            EventFactory.CreateContextEvent<EventContext.ColliderEvent>();

        #endregion
        
        #region Unity Callbacks

        private void OnTriggerEnter(Collider other)
        {
            OnEntered?.NotifyListeners(new EventContext.ColliderEvent
            {
                Collider = other
            });
        }

        private void OnTriggerExit(Collider other)
        {
            OnLeft?.NotifyListeners(new EventContext.ColliderEvent
            {
                Collider = other
            });
        }

        #endregion
    }
}