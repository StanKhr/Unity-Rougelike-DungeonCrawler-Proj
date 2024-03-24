using Player.Inventories.Interfaces;

namespace Miscellaneous
{
    public static class GameEvents
    {
        #region Types

        public class Event<T>
        {
            public Event(T value)
            {
                
            }
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