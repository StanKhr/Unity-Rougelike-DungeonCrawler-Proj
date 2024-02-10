using System;
using UnityEngine;

namespace Abilities.Interfaces
{
    public interface IColliderTrigger
    {
        #region Events

        event Action<Collider> OnEntered;
        event Action<Collider> OnLeft;

        #endregion
    }
}