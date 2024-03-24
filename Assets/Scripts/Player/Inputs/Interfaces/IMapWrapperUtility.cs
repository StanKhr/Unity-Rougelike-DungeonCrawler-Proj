using System;
using Miscellaneous.EventWrapper.Interfaces;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperUtility : IMapWrapper
    {
        #region Events

        IEvent OnInventory { get; }
        IEvent OnPauseMenu { get; }
        IEvent OnDiscardPressed { get; }

        #endregion
    }
}