using System;
using Player.Attacks;
using Player.Interfaces;
using UnityEngine;

namespace UI.Presenters
{
    public class AttackDamageApplierPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private AttackDamageApplier _attackDamageApplier;

        #endregion

        #region Properties

        private IAttackDamageApplier AttackDamageApplier => _attackDamageApplier;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            AttackDamageApplier.OnAttackChargeStarted += AttackChargeStarted;
        }

        private void AttackChargeStarted(float context)
        {
            AttackDamageApplier.OnAttackChargeStarted -= AttackChargeStarted;
        }

        private void OnDestroy()
        {
            
        }

        #endregion
    }
}