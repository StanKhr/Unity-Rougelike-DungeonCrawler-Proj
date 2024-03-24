using Abilities.Interfaces;
using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;

namespace Abilities.Triggers
{
    public class ColliderTrigger : MonoBehaviour, IColliderTrigger
    {
        #region Events

        public IContextEvent<Events.ColliderEvent> OnEntered { get; } = new ContextEvent<Events.ColliderEvent>();
        public IContextEvent<Events.ColliderEvent> OnLeft { get; } = new ContextEvent<Events.ColliderEvent>();

        #endregion
        
        #region Unity Callbacks

        private void OnTriggerEnter(Collider other)
        {
            OnEntered?.NotifyListeners(new Events.ColliderEvent
            {
                Collider = other
            });
        }

        private void OnTriggerExit(Collider other)
        {
            OnLeft?.NotifyListeners(new Events.ColliderEvent
            {
                Collider = other
            });
        }

        #endregion
    }
}