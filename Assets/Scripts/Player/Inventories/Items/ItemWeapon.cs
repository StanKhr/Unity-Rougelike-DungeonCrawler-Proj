using Player.Interfaces;
using Player.Inventories.Interfaces;
using Props.Interfaces;
using UnityEngine;

namespace Player.Inventories.Items
{
    [CreateAssetMenu (fileName = "Item_Weapon_NEW", menuName = "RPG / Items / Weapon Item")]
    public class ItemWeapon : Item, IUsable, IWeapon
    {
        #region Editor Fields

        [field: SerializeField] public Sprite WeaponHandSprite { get; private set; }

        #endregion
        
        #region Methods

        public bool TryUse(GameObject user)
        {
            if (!user.TryGetComponent<IGear>(out var gear))
            {
                return false;
            }

            if (gear.Weapon == (this as IWeapon))
            {
                gear.Weapon = null;
                return true;
            }
            
            gear.Weapon = this;
            return true;
        }

        #endregion
    }
}