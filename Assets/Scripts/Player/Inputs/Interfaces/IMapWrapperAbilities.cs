using System;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperAbilities : IMapWrapper
    {
        #region Events

        event Action OnTestInputPressed;

        #endregion
    }
}