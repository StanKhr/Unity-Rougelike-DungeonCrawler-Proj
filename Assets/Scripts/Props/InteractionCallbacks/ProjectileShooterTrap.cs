﻿using System;
using Props.Common;
using Props.Interfaces;
using Props.Projectiles;
using UnityEngine;

namespace Props.InteractionCallbacks
{
    public class ProjectileShooterTrap : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private ProjectileRigidbody _projectile;
        [SerializeField] private PressurePlate _pressurePlate;
        [SerializeField] private Transform _launchDummy;

        #endregion

        #region Properties

        private IInteractable Interactable => _pressurePlate;

        #endregion

        #region Unity Callbacks

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(_launchDummy.position, _launchDummy.forward * 20f);
        }
#endif

        private void OnEnable()
        {
            Interactable.OnInteractionStarted += InteractionStartedCallback;
        }

        private void OnDisable()
        {
            Interactable.OnInteractionStarted -= InteractionStartedCallback;
        }

        #endregion

        #region Methods

        private void InteractionStartedCallback(GameObject context)
        {
            var projectileInstance = Instantiate(_projectile, _launchDummy.position, _launchDummy.rotation);
            projectileInstance.Launch();
        }

        #endregion
    }
}