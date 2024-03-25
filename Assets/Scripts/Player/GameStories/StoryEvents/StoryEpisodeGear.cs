using System;
using Miscellaneous;
using Player.GameStories.Interfaces;
using Player.Interfaces;
using Player.Inventories;
using UnityEngine;
using UnityEngine.Localization;

namespace Player.GameStories.StoryEvents
{
    public class StoryEpisodeGear : StoryEpisode
    {
        #region Editor Fields

        [SerializeField] private Gear _gear;

        [SerializeField] private LocalizedString _equipped;
        [SerializeField] private LocalizedString _unequipped;

        #endregion
        
        #region Properties

        private IGear Gear => _gear;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            Gear.OnWeaponEquipped.AddListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.AddListener(WeaponRemovedCallback);
        }

        private void OnDisable()
        {
            Gear.OnWeaponEquipped.RemoveListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.RemoveListener(WeaponRemovedCallback);
        }

        #endregion

        #region Methods
        
        private void WeaponEquippedCallback(EventContext.WeaponEvent context)
        {
            CreateGenericEpisode(context.Weapon.Name, _equipped);
        }

        private void WeaponRemovedCallback(EventContext.WeaponEvent context)
        {
            CreateGenericEpisode(context.Weapon.Name, _unequipped);
        }

        #endregion
    }
}