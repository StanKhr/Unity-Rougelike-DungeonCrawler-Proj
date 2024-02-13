using System;
using Props.Interfaces;
using Props.Projectiles;
using UnityEngine;

namespace Props
{
    public class ProjectileShooterTrap : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private ProjectileRigidbody _projectile;
        [SerializeField] private GroundButton _groundButton;
        [SerializeField] private Transform _launchDummy;

        #endregion

        #region Properties

        private IInteractable Interactable => _groundButton;

        #endregion

        #region Unity Callbacks

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