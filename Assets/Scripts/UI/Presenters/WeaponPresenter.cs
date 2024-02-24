using System;
using Player.Interfaces;
using Player.Inventories;
using Player.Inventories.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Presenters
{
    public class WeaponPresenter : EquipmentPresenterBase
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
            if (weapon != null)
            {
                WeaponEquippedCallback(weapon);
            }
            else
            {
                WeaponRemovedCallback(null);
            }
            
            Gear.OnWeaponEquipped += WeaponEquippedCallback;
            Gear.OnWeaponRemoved += WeaponRemovedCallback;
        }

        private void OnDestroy()
        {
            Gear.OnWeaponEquipped -= WeaponEquippedCallback;
            Gear.OnWeaponRemoved -= WeaponRemovedCallback;
        }

        #endregion

        #region Methods
        
        private void WeaponEquippedCallback(IWeapon context)
        {
            SetValue(context.Name.GetLocalizedString());
        }

        private void WeaponRemovedCallback(IWeapon context)
        {
            SetValue(string.Empty);
        }

        #endregion
    }
}