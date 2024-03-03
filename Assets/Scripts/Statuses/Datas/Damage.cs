using System;
using Statuses.Enums;
using UnityEngine;

namespace Statuses.Datas
{
    [Serializable]
    public struct Damage
    {
        #region Constructors

        public Damage(float value, DamageType damageType, GameObject source = null)
        {
            Value = value;
            DamageType = damageType;
            Source = source;
        }

        #endregion

        #region Properties

        [field: SerializeField] public float Value { get; set; }
        [field: SerializeField] public DamageType DamageType { get; set; }
        [field: SerializeField] public GameObject Source { get; set; }

        #endregion
    }
}