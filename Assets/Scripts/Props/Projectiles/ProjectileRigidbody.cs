﻿using Abilities.Triggers;
using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using Player.Interfaces;
using Player.Miscellaneous;
using Props.Interfaces;
using UnityEngine;

namespace Props.Projectiles
{
    public class ProjectileRigidbody : MonoBehaviour, IProjectile
    {
        #region Events

        public IContextEvent<Events.GameObjectEvent> OnVictimFound { get; } =
            new ContextEvent<Events.GameObjectEvent>();
        
        #endregion
        
        #region Editor Fields

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ColliderTrigger _colliderTrigger;
        [SerializeField] private TimerComponent _selfDestroyTimer;
        
        [Header("Settings")]
        [SerializeField] private float _speed;

        #endregion

        #region Properties

        private ITimer SelfDestroyTimer => _selfDestroyTimer;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            _colliderTrigger.OnEntered.AddListener(EnteredCallback);

            SelfDestroyTimer?.OnTimerStarted.AddListener(SelfDestroyTimerStartedCallback);
        }

        private void OnDisable()
        {
            _colliderTrigger.OnEntered.RemoveListener(EnteredCallback);

            SelfDestroyTimer?.OnTimerStarted.RemoveListener(SelfDestroyTimerStartedCallback);
        }

        #endregion
        
        #region Methods

        private void SelfDestroyTimerStartedCallback()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        private void EnteredCallback(Events.ColliderEvent context)
        {
            if (context.Collider.isTrigger)
            {
                return;
            }

            if (SelfDestroyTimer == null)
            {
                OnVictimFound?.NotifyListeners(new Events.GameObjectEvent
                {
                    GameObject = context.Collider.gameObject
                });
                return;
            }

            if (SelfDestroyTimer.InProgress)
            {
                return;
            }
            
            OnVictimFound?.NotifyListeners(new Events.GameObjectEvent
            {
                GameObject = context.Collider.gameObject
            });
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