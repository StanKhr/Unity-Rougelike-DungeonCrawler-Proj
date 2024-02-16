using System;
using Miscellaneous;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class EyeScanner : MonoBehaviour
    {
        #region Events

        public event DelegateHolder.GameObjectEvents OnTargetFound;
        public event Action OnTargetLost;

        #endregion
        
        #region Editor Fields

        [SerializeField] private float _rayMaxDistance = 5f;
        [SerializeField] private LayerMask _scannedLayers;

        #endregion

        #region Fields

        private GameObject _target;

        #endregion

        #region Properties

        private GameObject Target
        {
            get => _target;
            set
            {
                if (Target == value)
                {
                    return;
                }

                _target = value;
                if (value)
                {
                    OnTargetFound?.Invoke(value);
                    return;
                }

                OnTargetLost?.Invoke();
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