using Audio.Interfaces;
using Player.Inventories.Enums;
using Statuses.Enums;
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
        DamageType DamageType { get; }
        IClipSelector ClipSelectorAttackCharge { get; }
        IClipSelector ClipSelectorAttackRelease { get; }

        #endregion

        #region Methods

        float GetScaleMultiplier(AttributeScaleType attributeScaleType);
        float CalculateChargeTimeSeconds();
        IClipSelector GetCorrespondingHitClipSelector();

        #endregion
    }
}