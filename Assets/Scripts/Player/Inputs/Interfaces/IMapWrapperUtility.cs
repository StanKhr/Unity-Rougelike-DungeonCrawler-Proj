using System;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperUtility : IMapWrapper
    {
        #region Events

        event Action OnInventory;
        event Action OnPauseMenu;

        #endregion
    }
}