using System;
using Abilities.Interfaces;
using Abilities.Triggers;
using Miscellaneous;
using Props.Interfaces;
using Statuses.Interfaces;
using UnityEngine;

namespace Props
{
    public class GroundButton : MonoBehaviour, IInteractable
    {
        #region Events
        
        public event DelegateHolder.GameObjectEvents OnInteractionStarted;
        public event DelegateHolder.GameObjectEvents OnInteractionEnded;

        #endregion
        
        #region Editor Fields

        [SerializeField] private ColliderTrigger _colliderTrigger;

        #endregion

        #region Properties

        private IColliderTrigger ColliderTrigger => _colliderTrigger;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            ColliderTrigger.OnEntered += EnteredCallback;
            ColliderTrigger.OnLeft += LeftCallback;
        }

        private void OnDisable()
        {
            ColliderTrigger.OnEntered -= EnteredCallback;
            ColliderTrigger.OnLeft -= LeftCallback;
        }

        #endregion

        #region Methods
        
        private void EnteredCallback(Collider obj)
        {
            OnInteractionStarted?.Invoke(obj.gameObject);
        }

        private void LeftCallback(Collider obj)
        {
            OnInteractionEnded?.Invoke(obj.gameObject);
        }

        #endregion
    }
}