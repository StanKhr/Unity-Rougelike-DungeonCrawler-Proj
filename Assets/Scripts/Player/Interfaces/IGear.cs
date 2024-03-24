using Miscellaneous.CustomEvents.Contexts;
using Miscellaneous.CustomEvents.Events;
using Player.Inventories.Interfaces;

namespace Player.Interfaces
{
    public interface IGear
    {
        #region Events

        ValueEvent<EventContext.WeaponEvent> OnWeaponEquipped { get; }
        ValueEvent<EventContext.WeaponEvent> OnWeaponRemoved { get; }

        #endregion
        
        #region Properties
        
        IWeapon Weapon { get; set; }
        bool WeaponEquipped => Weapon != null;

        #endregion
    }
}