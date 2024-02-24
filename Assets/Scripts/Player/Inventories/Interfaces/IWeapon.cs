using UnityEngine;

namespace Player.Inventories.Interfaces
{
    public interface IWeapon
    {
        #region Properties

        Sprite WeaponHandSprite { get; }
        float AttackValue { get; }
        float SpeedValue { get; }

        #endregion
    }
}