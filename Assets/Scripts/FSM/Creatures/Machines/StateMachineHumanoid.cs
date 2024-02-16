﻿using System;
using Abilities.Interfaces;
using Abilities.Locomotion;
using FSM.Creatures.Interfaces;
using FSM.Main;
using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;

namespace FSM.Creatures.Machines
{
    public abstract class StateMachineHumanoid : StateMachine, IStateMachineHumanoid
    {
        #region Editor Fields

        [SerializeField] private LocomotionCharacterController _locomotionCharacterController;
        [SerializeField] private Health _health;

        #endregion

        #region Properties

        public ILocomotion Locomotion => _locomotionCharacterController;
        public IHealth Health => _health;
        public IDamageable Damageable => _health;

        #endregion

        #region Unity Callbacks

        protected override void Start()
        {
            base.Start();
        }

        private void OnEnable()
        {
            Damageable.OnDamaged += DamagedCallback;
        }

        private void OnDisable()
        {
            Damageable.OnDamaged -= DamagedCallback;
        }

        #endregion

        #region Callbacks
        
        private void DamagedCallback(float context)
        {
            if (Health.CurrentValue > 0f)
            {
                return;
            }

            ToDeathState();
        }

        #endregion

        #region Abstract Methods

        public abstract void ToFreeLookState();
        public abstract void ToDeathState();

        #endregion
    }
}