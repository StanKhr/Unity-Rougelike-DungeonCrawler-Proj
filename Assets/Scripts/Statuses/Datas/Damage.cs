using System;
using Statuses.Enums;
using UnityEngine;

namespace Statuses.Datas
{
    [Serializable]
    public struct Damage
    {
        #region Constructors

        public Damage(float value, DamageType damageType, GameObject source = null, bool critApplied = false)
        {
            Value = value;
            DamageType = damageType;
            Source = source;
            CritApplied = critApplied;
        }

        #endregion

        #region Properties

        [field: SerializeField] public float Value { get; set; }
        [field: SerializeField] public DamageType DamageType { get; set; }
        [field: SerializeField] public GameObject Source { get; set; }
        [field: SerializeField] public bool CritApplied { get; set; }

        #endregion
    }
}