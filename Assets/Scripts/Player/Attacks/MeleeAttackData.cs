using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.Attacks
{
    public struct MeleeAttackData
    {
        #region Constructors

        public MeleeAttackData(IWeapon weapon, float critChargePercent, bool critApplied, GameObject attackVictim)
        {
            Weapon = weapon;
            CritChargePercent = critChargePercent;
            CritApplied = critApplied;
            AttackVictim = attackVictim;
        }

        #endregion
        
        #region Properties

        public IWeapon Weapon { get; }
        public float CritChargePercent { get; }
        public bool CritApplied { get; }
        public GameObject AttackVictim { get; }

        #endregion
    }
}