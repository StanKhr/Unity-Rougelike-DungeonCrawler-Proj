using System;
using Player.Attacks;
using Player.Interfaces;
using UnityEngine;

namespace UI.Presenters
{
    public class AttackDamageApplierPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private PlayerMeleeAttack _playerMeleeAttack;

        #endregion

        #region Properties

        private IPlayerMeleeAttack PlayerMeleeAttack => _playerMeleeAttack;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            
        }

        private void PlayerMeleeAttackChargeStarted(float context)
        {
            
        }

        private void OnDestroy()
        {
            
        }

        #endregion
    }
}