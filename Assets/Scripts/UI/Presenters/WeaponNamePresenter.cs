using Miscellaneous.CustomEvents.Contexts;
using Player.Interfaces;
using Player.Inventories;
using UnityEngine;

namespace UI.Presenters
{
    public class WeaponNamePresenter : EquipmentPresenterBase
    {
        #region Editor Fields

        [SerializeField] private Gear _gear;

        #endregion

        #region Properties

        private IGear Gear => _gear;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            var weapon = Gear.Weapon;
            SetValue(weapon != null ? weapon.Name : string.Empty);

            Gear.OnWeaponEquipped.AddCallback(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.AddCallback(WeaponRemovedCallback);
        }

        private void OnDestroy()
        {
            Gear.OnWeaponEquipped.RemoveCallback(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.RemoveCallback(WeaponRemovedCallback);
        }

        #endregion

        #region Methods
        
        protected virtual void WeaponEquippedCallback(EventContext.WeaponEvent context)
        {
            SetValue(context.Weapon.Name);
        }

        protected virtual void WeaponRemovedCallback(EventContext.WeaponEvent context)
        {
            SetValue(string.Empty);
        }

        #endregion
    }
}