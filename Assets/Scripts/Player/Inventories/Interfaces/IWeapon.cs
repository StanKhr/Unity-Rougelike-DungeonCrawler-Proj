using Player.Inventories.Enums;
using UnityEngine;

namespace Player.Inventories.Interfaces
{
    public interface IWeapon : IItem
    {
        #region Properties

        Sprite WeaponHandSprite { get; }
        float DamageValue { get; }
        float SpeedValue { get; }
        float AttackDuration { get; }
        AttributeScaleType ScaleStrength { get; }
        AttributeScaleType ScaleDexterity { get; }
        AttributeScaleType ScaleIntellect { get; }

        #endregion

        #region Methods

        float GetScaleMultiplier(AttributeScaleType attributeScaleType);
        float CalculateChargeTimeSeconds();

        #endregion
    }
}