using Abilities.Interfaces;
using Abilities.Triggers;
using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public class PressurePlate : MonoBehaviour, IInteractable
    {
        #region Events

        public IContextEvent<Events.GameObjectEvent> OnInteractionStarted { get; } =
            new ContextEvent<Events.GameObjectEvent>();
        public IContextEvent<Events.GameObjectEvent> OnInteractionEnded { get; } =
            new ContextEvent<Events.GameObjectEvent>();

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
        
        private void EnteredCallback(Events.ColliderEvent context)
        {
            if (_singleUse && _wasUsed)
            {
                return;
            }

            _wasUsed = true;
            OnInteractionStarted?.NotifyListeners(new Events.GameObjectEvent
            {
                GameObject = context.Collider.gameObject
            });
        }

        private void LeftCallback(Events.ColliderEvent context)
        {
            OnInteractionEnded?.NotifyListeners(new Events.GameObjectEvent
            {
                GameObject = context.Collider.gameObject
            });
        }

        #endregion
    }
}