using System;
using Miscellaneous.EventWrapper.Interfaces;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperAbilities : IMapWrapper
    {
        #region Events

        IEvent OnTestInputPressed { get; }
        IEvent OnInteracted { get; }

        #endregion

        #region Properties

        bool AttackInputHolding { get; }

        #endregion
    }
}