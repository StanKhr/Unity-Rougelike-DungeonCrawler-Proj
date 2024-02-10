﻿using System;
using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;

namespace UI.Presenters
{
    public abstract class DamageFeedback : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Health _health;

        #endregion

        #region Properties

        private IDamageable Damageable => _health;

        #endregion

        #region Unity Callbacks

        protected virtual void OnEnable()
        {
            Damageable.OnDamaged += DamagedCallback;
        }

        protected virtual void OnDisable()
        {
            Damageable.OnDamaged -= DamagedCallback;
        }

        #endregion
        
        #region Methods

        protected abstract void DamagedCallback(float context);

        #endregion
    }
}