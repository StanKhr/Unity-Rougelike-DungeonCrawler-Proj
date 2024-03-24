using Abilities.Interfaces;
using Abilities.Triggers;
using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class PressurePlate : MonoBehaviour, IInteractable
    {
        #region Events

        public IContextEvent<EventContext.GameObjectEvent> OnInteractionStarted { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();
        public IContextEvent<EventContext.GameObjectEvent> OnInteractionEnded { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();

        #endregion
        
        #region Editor Fields

        [SerializeField] private ColliderTrigger _colliderTrigger;
        [SerializeField] private bool _singleUse;
 
        #endregion

        #region Properties

        private IColliderTrigger ColliderTrigger => _colliderTrigger;

        #endregion

        #region Fields

        private bool _wasUsed;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            ColliderTrigger.OnEntered.AddListener(EnteredCallback);
            ColliderTrigger.OnLeft.AddListener(LeftCallback);
        }

        private void OnDisable()
        {
            ColliderTrigger.OnEntered.RemoveListener(EnteredCallback);
            ColliderTrigger.OnLeft.RemoveListener(LeftCallback);
        }

        #endregion

        #region Methods
        
        private void EnteredCallback(EventContext.ColliderEvent context)
        {
            if (_singleUse && _wasUsed)
            {
                return;
            }

            _wasUsed = true;
            OnInteractionStarted?.NotifyListeners(new EventContext.GameObjectEvent
            {
                GameObject = context.Collider.gameObject
            });
        }

        private void LeftCallback(EventContext.ColliderEvent context)
        {
            OnInteractionEnded?.NotifyListeners(new EventContext.GameObjectEvent
            {
                GameObject = context.Collider.gameObject
            });
        }

        #endregion
    }
}