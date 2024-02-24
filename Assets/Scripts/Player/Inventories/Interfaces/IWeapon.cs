using Player.Inventories.Enums;
using UnityEngine;

namespace Player.Inventories.Interfaces
{
    public interface IWeapon : IItem
    {
        #region Properties

        Sprite WeaponHandSprite { get; }
        float AttackValue { get; }
        float SpeedValue { get; }
        AttributeScaleType ScaleStrength { get; }
        AttributeScaleType ScaleDexterity { get; }
        AttributeScaleType ScaleIntellect { get; }

        #endregion
    }
}