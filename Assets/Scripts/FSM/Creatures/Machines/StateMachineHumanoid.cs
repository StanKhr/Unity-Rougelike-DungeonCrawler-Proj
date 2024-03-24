using Abilities.Interfaces;
using Abilities.Locomotion;
using FSM.Creatures.Interfaces;
using FSM.Main;
using Miscellaneous.EventWrapper.Main;
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

        public GameObject GameObject => gameObject;
        public ILocomotion Locomotion => _locomotionCharacterController;
        public IHealth Health => _health;
        public IDamageable Damageable => _health;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            Damageable.OnDamaged.AddListener(DamagedCallback);
        }

        private void OnDisable()
        {
            Damageable.OnDamaged.RemoveListener(DamagedCallback);
        }

        #endregion

        #region Callbacks
        
        private void DamagedCallback(Events.FloatEvent context)
        {
            if (Health.CurrentValue > 0f)
            {
                return;
            }

            ToDeathState();
        }

        #endregion

        #region Methods
        
        public void Resurrect()
        {
            Health.SetValue(Health.MaxValue);
            ToFreeLookState();
        }

        #endregion

        #region Abstract Methods

        public abstract void ToFreeLookState();
        public abstract void ToDeathState();

        #endregion
    }
}