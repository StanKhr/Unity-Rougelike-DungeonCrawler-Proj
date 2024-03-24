using Miscellaneous;
using Player.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class EyeScanner : MonoBehaviour, IEyeScanner
    {
        #region Events

        public IContextEvent<EventContext.GameObjectEvent> OnTargetFound { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();
        public IEvent OnTargetLost { get; } = EventFactory.CreateEvent();

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
                    OnTargetFound?.NotifyListeners(new EventContext.GameObjectEvent
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