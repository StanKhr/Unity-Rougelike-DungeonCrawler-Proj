﻿using System;
using Miscellaneous;
using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;

namespace Props.Common
{
    public class DamageFeedbackAnimations : DamageFeedback
    {
        #region Constants

        private static readonly int DamagedHash = Animator.StringToHash("Damaged");
        private static readonly int KilledHash = Animator.StringToHash("Killed");
        private static readonly int ResurrectedHash = Animator.StringToHash("Resurrected");

        #endregion

        #region Editor Fields

        [SerializeField] private Animator _animator;

        #endregion

        #region Methods
        
        protected override void DamagedCallback(float context)
        {
            if (Health.Alive)
            {
                _animator.Play(DamagedHash);
                return;
            }
            
            _animator.Play(KilledHash);
        }

        #endregion
    }
}