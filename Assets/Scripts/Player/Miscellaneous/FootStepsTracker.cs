using System;
using Abilities.Interfaces;
using Player.Cameras.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using UnityEngine;

namespace Player.Miscellaneous
{
    public class FootStepsTracker : MonoBehaviour, IFootStepsTracker
    {
        #region Events

        public IEvent OnStepMade { get; } = new CustomEvent();

        #endregion

        #region Editor Fields

        [SerializeField] private float _minStepMagnitude = 1f;

        #endregion

        #region Fields

        private float _stepDistance;

        #endregion

        #region Properties

        private float StepDistance
        {
            get => _stepDistance;
            set
            {
                if (value <= 0f)
                {
                    return;
                }

                if (value >= _minStepMagnitude)
                {
                    _stepDistance = 0f;
                    OnStepMade?.NotifyListeners();
                    
                    return;
                }

                _stepDistance = value;
            }
        }

        #endregion

        #region Methods

        public void Tick(ILocomotion locomotion, float deltaTime)
        {
            if (!locomotion.Grounded)
            {
                return;
            }
            
            StepDistance += locomotion.BodyVelocity.magnitude * deltaTime;
        }

        #endregion
    }
}