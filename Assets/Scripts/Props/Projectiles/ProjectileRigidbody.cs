using Abilities.Triggers;
using Miscellaneous;
using Props.Interfaces;
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

        public void Launch()
        {
            Launch(_rigidbody.position, _rigidbody.transform.forward);
        }

        public void Launch(Vector3 direction)
        {
            Launch(_rigidbody.position, direction);
        }

        public void Launch(Vector3 position, Vector3 direction)
        {
            if (_rigidbody.position != position)
            {
                _rigidbody.position = position;
            }

            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            if (_rigidbody.rotation != rotation)
            {
                _rigidbody.rotation = rotation;
            }
            
            _rigidbody.AddForce(direction.normalized * _speed, ForceMode.Acceleration);
        }

        #endregion
    }
}