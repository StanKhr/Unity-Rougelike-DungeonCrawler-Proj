using Abilities.Triggers;
using Cinemachine;
using Miscellaneous;
using Miscellaneous.ObjectPooling;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using Props.Interfaces;
using UnityEngine;

namespace Props.Projectiles
{
    public class ProjectileRigidbody : PooledObject, IProjectile
    {
        #region Events

        public IContextEvent<EventContext.GameObjectEvent> OnVictimFound { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();
        
        #endregion
        
        #region Editor Fields

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ColliderTrigger _colliderTrigger;
        
        [Header("Settings")]
        [SerializeField] private float _speed;

        #endregion

        #region Unity Callbacks

        protected override void OnEnable()
        {
            ResetVelocity();
            
            _colliderTrigger.OnEntered.AddListener(EnteredCallback);
            
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            _colliderTrigger.OnEntered.RemoveListener(EnteredCallback);
            
            base.OnDisable();
        }

        #endregion
        
        #region Methods
        
        private void EnteredCallback(EventContext.TriggerEnterEvent context)
        {
            if (context.Collider.isTrigger)
            {
                return;
            }

            OnVictimFound?.NotifyListeners(new EventContext.GameObjectEvent
            {
                GameObject = context.Collider.gameObject
            });
            
            ResetVelocity();
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

        private void ResetVelocity()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        #endregion
    }
}