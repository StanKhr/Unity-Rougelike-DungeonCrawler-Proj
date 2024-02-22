using Miscellaneous;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.Inventories
{
    public class Gear : MonoBehaviour, IGear
    {
        #region Events

        public event DelegateHolder.WeaponEvents OnWeaponEquipped;
        public event DelegateHolder.WeaponEvents OnWeaponRemoved;

        #endregion

        #region Fields

        private IWeapon _weapon;

        #endregion

        #region Properties

        public IWeapon Weapon
        {
            get => _weapon;
            set
            {
                var prevWeapon = Weapon;
                _weapon = value;

                if (Weapon != null)
                {
                    OnWeaponEquipped?.Invoke(Weapon);
                    return;
                }
                
                OnWeaponRemoved?.Invoke(prevWeapon);
            }
        }

        #endregion
    }
}