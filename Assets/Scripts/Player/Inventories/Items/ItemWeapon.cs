using System.Collections.Generic;
using Audio.ClipSelectors;
using Audio.ClipSelectors.Pure;
using Audio.Interfaces;
using Player.Interfaces;
using Player.Inventories.Enums;
using Player.Inventories.Interfaces;
using Props.Interfaces;
using Statuses.Enums;
using UI.Utility;
using UnityEngine;

namespace Player.Inventories.Items
{
    [CreateAssetMenu (fileName = "Item_Weapon_NEW", menuName = "RPG / Items / Weapon")]
    public class ItemWeapon : Item, IUsable, IWeapon
    {
        #region Constants

        private const float SpeedSecondValue = 60;

        #endregion
        
        #region Constants
        
        // attribute scale type and corresponding modifier value
        private static readonly Dictionary<AttributeScaleType, float> AttributeScaleModifiers = new()
        {
            {AttributeScaleType.None, 0.0f},
            {AttributeScaleType.S, 1.2f},
            {AttributeScaleType.A, 1.0f},
            {AttributeScaleType.B, 0.8f},
            {AttributeScaleType.C, 0.6f},
            {AttributeScaleType.D, 0.5f},
            {AttributeScaleType.E, 0.3f},
            {AttributeScaleType.F, 0.2f},
        };

        #endregion
        
        #region Editor Fields

        [field: SerializeField] public Sprite WeaponHandSprite { get; private set; }
        [field: SerializeField] public float DamageValue { get; private set; }
        [field: SerializeField] public float SpeedValue { get; private set; }
        [field: SerializeField] public float AttackDuration { get; private set; } = 0.5f;
        [field: SerializeField] public AttributeScaleType ScaleStrength { get; private set; }
        [field: SerializeField] public AttributeScaleType ScaleDexterity { get; private set; }
        [field: SerializeField] public AttributeScaleType ScaleIntellect { get; private set; }
        [field: SerializeField] public DamageType DamageType { get; private set; } = DamageType.MeleeSlash;

        [Header("Audio")]
        [SerializeField] private ClipSelectorPure _clipSelectorChargeAttack;
        [SerializeField] private ClipSelectorPure _clipSelectorReleaseAttack;
        [SerializeField] private ClipSelectorPure _clipSelectorHit;
        #endregion
        
        #region Properties

        public override string CombinedDescription => ItemDescriptionBuilder.Instance.Build(this);
        public IClipSelector ClipSelectorAttackRelease => _clipSelectorReleaseAttack;
        public IClipSelector ClipSelectorAttackCharge => _clipSelectorChargeAttack;
        
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

        public float GetScaleMultiplier(AttributeScaleType attributeScaleType)
        {
            return AttributeScaleModifiers.GetValueOrDefault(attributeScaleType, 0f);
        }

        public float CalculateChargeTimeSeconds()
        {
            return SpeedSecondValue / SpeedValue;
        }

        public IClipSelector GetCorrespondingHitClipSelector()
        {
            //todo: check for hit surface type; armor etc; return corresponding audio
            return _clipSelectorHit;
        }

        #endregion
    }
}