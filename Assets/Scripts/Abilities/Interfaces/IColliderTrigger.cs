using System;
using Miscellaneous;
using UnityEngine;

namespace Abilities.Interfaces
{
    public interface IColliderTrigger
    {
        #region Events

        event DelegateHolder.ColliderEvents OnEntered;
        event DelegateHolder.ColliderEvents OnLeft;

        #endregion
    }
}