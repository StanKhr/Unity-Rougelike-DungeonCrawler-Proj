using System;
using Abilities.Interfaces;
using Miscellaneous;
using UnityEngine;

namespace Abilities.Triggers
{
    public class ColliderTrigger : MonoBehaviour, IColliderTrigger
    {
        #region Events
        
        public event DelegateHolder.ColliderEvents OnEntered;
        public event DelegateHolder.ColliderEvents OnLeft;

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