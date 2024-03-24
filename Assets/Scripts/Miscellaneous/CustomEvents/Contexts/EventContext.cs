using Player.Inventories.Interfaces;
using UnityEngine;

namespace Miscellaneous.CustomEvents.Contexts
{
    public static class EventContext
    {
        #region Types
        
        public struct GameObjectEvent
        {
            public GameObject GameObject { get; set; }
        }
        
        public struct WeaponEvent
        {
            public IWeapon Weapon { get; set; }
        }
        
        public struct MeleeAttackEvent
        {
            public IWeapon Weapon { get; set; }
            public float CritChargePercent { get; set; }
            public bool CritApplied { get; set; }
        }

        #endregion
    }
}