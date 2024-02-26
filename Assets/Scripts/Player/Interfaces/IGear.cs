using Miscellaneous;
using Player.Inventories.Interfaces;

namespace Player.Interfaces
{
    public interface IGear
    {
        #region MyRegion

        event DelegateHolder.WeaponEvents OnWeaponEquipped;
        event DelegateHolder.WeaponEvents OnWeaponRemoved;

        #endregion
        
        #region Properties
        
        IWeapon Weapon { get; set; }
        bool WeaponEquipped => Weapon != null;

        #endregion
    }
}