using System;
using Abilities.Interfaces;
using UnityEngine;

namespace Abilities.Triggers
{
    public class ColliderTrigger : MonoBehaviour, IColliderTrigger
    {
        #region Events
        
        public event Action<Collider> OnEntered;
        public event Action<Collider> OnLeft;

        #endregion
        
        #region Unity Callbacks

        private void OnTriggerEnter(Collider other)
        {
            OnEntered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnLeft?.Invoke(other);
        }

        #endregion
    }
}