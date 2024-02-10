using System;
using Statuses.Enums;
using UnityEngine;

namespace Statuses.Datas
{
    [Serializable]
    public struct Damage
    {
        #region Constructors

        public Damage(float value, DamageType damageType)
        {
            Value = value;
            DamageType = damageType;
        }

        #endregion

        #region Properties

        [field: SerializeField] public float Value { get; set; }
        [field: SerializeField] public DamageType DamageType { get; set; }

        #endregion
    }
}