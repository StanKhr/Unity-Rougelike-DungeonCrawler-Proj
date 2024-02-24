using System;
using Abilities.Interfaces;

namespace Player.Cameras.Interfaces
{
    public interface IFootStepsTracker
    {
        #region Events

        event Action OnStepMade;

        #endregion

        #region Methods

        void Tick(ILocomotion locomotion, float deltaTime);

        #endregion
    }
}