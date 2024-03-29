﻿using Player.Interfaces;
using Player.Inventories;
using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.Hands
{
    public class HandsAnimations : MonoBehaviour
    {
        #region Types

        private class HandProperty
        {
            private SpriteRenderer _spriteRenderer;

            public SpriteRenderer SpriteRenderer
            {
                get => _spriteRenderer;
                set
                {
                    if (_spriteRenderer)
                    {
                        _spriteRenderer.gameObject.SetActive(false);
                    }

                    _spriteRenderer = value;
                    
                    if (_spriteRenderer)
                    {
                        _spriteRenderer.gameObject.SetActive(true);
                    }
                }
            }
        }

        #endregion
        
        #region Editor Fields

        [SerializeField] private Gear _gear;

        [Header("Hands")]
        [SerializeField] private SpriteRenderer _handRightEmpty;
        [SerializeField] private SpriteRenderer _handRightWeapon;
        [SerializeField] private SpriteRenderer _handLeftEmpty;
        [SerializeField] private SpriteRenderer _handLeftUtility;

        #endregion

        #region Fields

        private readonly HandProperty _handRight = new();
        // private readonly HandProperty _handLeft = new();

        #endregion

        #region Properties

        private IGear Gear => _gear;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            ValidateHands();
            
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

        private void ValidateHands()
        {
            if (Gear.WeaponEquipped)
            {
                WeaponEquippedCallback(Gear.Weapon);
                return;
            }
            
            WeaponRemovedCallback(null);
        }

        private void WeaponEquippedCallback(IWeapon context)
        {
            _handRight.SpriteRenderer = _handRightWeapon;
            _handRight.SpriteRenderer.sprite = context.WeaponHandSprite;
        }

        private void WeaponRemovedCallback(IWeapon context)
        {
            _handRight.SpriteRenderer = _handRightEmpty;
        }

        #endregion
    }
}