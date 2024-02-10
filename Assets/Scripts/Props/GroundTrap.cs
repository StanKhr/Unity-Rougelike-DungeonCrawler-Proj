using System;
using Abilities.Interfaces;
using Abilities.Triggers;
using Props.Interfaces;
using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Props
{
    public class GroundTrap : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private GroundButton _groundButton;
        [SerializeField] private Damage _damage;

        #endregion

        #region Properties

        private IInteractable GroundButton => _groundButton;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            GroundButton.OnInteractionStarted += EnteredCallback;
        }

        private void OnDisable()
        {
            GroundButton.OnInteractionStarted -= EnteredCallback;
        }

        #endregion

        #region Methods


        private void EnteredCallback(GameObject context)
        {
            if (!context.TryGetComponent<IDamageable>(out var damageable))
            {
                return;
            }
            
            damageable.ApplyDamage(_damage);
        }

        #endregion
    }
}