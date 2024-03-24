using Miscellaneous;
using Player.Interfaces;
using Player.Inventories;
using Plugins.StanKhrEssentials.EventWrapper.Main;
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

            Gear.OnWeaponEquipped.AddListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.AddListener(WeaponRemovedCallback);
        }

        private void OnDestroy()
        {
            Gear.OnWeaponEquipped.RemoveListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.RemoveListener(WeaponRemovedCallback);
        }

        #endregion

        #region Methods
        
        protected virtual void WeaponEquippedCallback(Events.WeaponEvent context)
        {
            SetValue(context.Weapon.Name);
        }

        protected virtual void WeaponRemovedCallback(Events.WeaponEvent context)
        {
            SetValue(string.Empty);
        }

        #endregion
    }
}