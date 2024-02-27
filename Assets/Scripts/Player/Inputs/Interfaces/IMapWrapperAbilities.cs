using System;
using Miscellaneous;

namespace Player.Inputs.Interfaces
{
    public interface IMapWrapperAbilities : IMapWrapper
    {
        #region Events

        event Action OnTestInputPressed;
        event Action OnInteracted;
        event Action OnAttackInputPressed;

        #endregion

        #region Properties

        bool AttackInputHolding { get; }

        #endregion
    }
}