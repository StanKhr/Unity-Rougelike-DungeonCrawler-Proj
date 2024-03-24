using System;
using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using Player.Interfaces;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class EyeScanner : MonoBehaviour, IEyeScanner
    {
        #region Events

        public IContextEvent<Events.GameObjectEvent> OnTargetFound { get; } =
            new ContextEvent<Events.GameObjectEvent>();
        public IEvent OnTargetLost { get; } = new CustomEvent();

        #endregion
        
        #region Editor Fields

        [SerializeField] private float _rayMaxDistance = 5f;
        [SerializeField] private LayerMask _scannedLayers;

        #endregion

        #region Fields

        private GameObject _target;

        #endregion

        #region Properties

        public GameObject Target
        {
            get => _target;
            private set
            {
                if (Target == value)
                {
                    return;
                }

                _target = value;
                if (value)
                {
                    OnTargetFound?.NotifyListeners(new Events.GameObjectEvent
                    {
                        GameObject = value
                    });
                    return;
                }

                OnTargetLost?.NotifyListeners();
            }
        }

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            var castResult = Physics.Raycast(transform.position, transform.forward, 
                out var hit, _rayMaxDistance, _scannedLayers, QueryTriggerInteraction.Collide);
            
            if (!castResult)
            {
                Target = null;
                return;
            }

            Target = hit.collider.gameObject;
        }

        #endregion
    }
}