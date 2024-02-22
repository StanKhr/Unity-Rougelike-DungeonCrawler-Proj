using System;
using Props.Interfaces;
using UnityEngine;

namespace Player.Inventories.Items
{
    [CreateAssetMenu (fileName = "Item_Weapon_NEW", menuName = "RPG / Items / Weapon Item")]
    public class ItemWeapon : Item, IUsable
    {
        #region Editor Fields

        [SerializeField] private Sprite _weaponHandSprite;

        #endregion
        
        #region Methods

        public bool TryUse(GameObject user)
        {
            return false;
        }

        #endregion
    }
}