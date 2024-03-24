using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Main;
using Player.Inventories.Interfaces;

namespace Player.Interfaces
{
    public interface IGear
    {
        #region Events

        ContextEvent<Events.WeaponEvent> OnWeaponEquipped { get; }
        ContextEvent<Events.WeaponEvent> OnWeaponRemoved { get; }

        #endregion
        
        #region Properties
        
        IWeapon Weapon { get; set; }
        bool WeaponEquipped => Weapon != null;

        #endregion
    }
}