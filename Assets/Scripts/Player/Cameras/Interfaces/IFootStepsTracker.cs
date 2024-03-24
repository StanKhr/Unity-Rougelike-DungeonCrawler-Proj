using System;
using Abilities.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;

namespace Player.Cameras.Interfaces
{
    public interface IFootStepsTracker
    {
        #region Events

        IEvent OnStepMade { get; }

        #endregion

        #region Methods

        void Tick(ILocomotion locomotion, float deltaTime);

        #endregion
    }
}