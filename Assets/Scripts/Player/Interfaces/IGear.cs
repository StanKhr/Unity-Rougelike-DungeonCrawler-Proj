using Miscellaneous;
using Player.Inventories.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Main;

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