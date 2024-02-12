using System;
using Abilities.Triggers;
using Miscellaneous;
using Props.Interfaces;
using Statuses.Datas;
using UnityEngine;

namespace Props.Projectiles
{
    public class ProjectileRigidbody : MonoBehaviour, IProjectile
    {
        #region Events
        
        public event DelegateHolder.GameObjectEvents OnVictimFound;

        #endregion
        
        #region Editor Fields

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ColliderTrigger _colliderTrigger;
        
        [Header("Settings")]
        [SerializeField] private float _speed;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            _colliderTrigger.OnEntered += EnteredCallback;
        }

        private void OnDisable()
        {
            _colliderTrigger.OnEntered -= EnteredCallback;
        }

        #endregion
        
        #region Methods

        private void EnteredCallback(Collider context)
        {
            OnVictimFound?.Invoke(context.gameObject);
        }

        [ContextMenu("Test launch")]
        private void Test()
        {
            Launch(_rigidbody.position, -Vector3.forward);
        }

        public void Launch(Vector3 position, Vector3 direction)
        {
            _rigidbody.position = position;
            _rigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
            
            _rigidbody.AddForce(direction.normalized * _speed, ForceMode.Acceleration);
        }

        #endregion
    }
}