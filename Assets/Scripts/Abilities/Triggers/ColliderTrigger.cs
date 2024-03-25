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

        public IContextEvent<EventContext.TriggerEnterEvent> OnEntered { get; } =
            EventFactory.CreateContextEvent<EventContext.TriggerEnterEvent>();
        public IContextEvent<EventContext.TriggerEnterEvent> OnLeft { get; } =
            EventFactory.CreateContextEvent<EventContext.TriggerEnterEvent>();

        #endregion
        
        #region Unity Callbacks

        private void OnTriggerEnter(Collider other)
        {
            OnEntered?.NotifyListeners(new EventContext.TriggerEnterEvent()
            {
                Collider = other,
                HitPoint = other.ClosestPoint(transform.position)
            });
        }

        private void OnTriggerExit(Collider other)
        {
            OnLeft?.NotifyListeners(new EventContext.TriggerEnterEvent()
            {
                Collider = other,
                HitPoint = other.ClosestPoint(transform.position)
            });
        }

        #endregion
    }
}