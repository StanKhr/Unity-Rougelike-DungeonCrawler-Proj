using System;
using UnityEngine;

namespace Abilities.Locomotion
{
    [Serializable]
    public struct LocomotionData
    {
        #region Editor Fields

        [field: SerializeField] public float Speed { get; private set; }

        #endregion
    }
}