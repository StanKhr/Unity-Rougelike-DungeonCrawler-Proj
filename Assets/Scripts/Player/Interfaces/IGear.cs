using Miscellaneous;
using Player.Inventories.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;

namespace Player.Interfaces
{
    public interface IGear
    {
        #region Events

        IContextEvent<EventContext.WeaponEvent> OnWeaponEquipped { get; }
        IContextEvent<EventContext.WeaponEvent> OnWeaponRemoved { get; }

        #endregion
        
        #region Properties
        
        IWeapon Weapon { get; set; }
        bool WeaponEquipped => Weapon != null;

        #endregion
    }
}