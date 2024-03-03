using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.Attacks
{
    public struct MeleeAttackData
    {
        #region Constructors

        public MeleeAttackData(IWeapon weapon, float critChargePercent, bool critApplied)
        {
            Weapon = weapon;
            CritChargePercent = critChargePercent;
            CritApplied = critApplied;
        }

        #endregion
        
        #region Properties

        public IWeapon Weapon { get; }
        public float CritChargePercent { get; }
        public bool CritApplied { get; }
        
        #endregion
    }
}