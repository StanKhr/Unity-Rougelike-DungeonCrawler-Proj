using Miscellaneous;
using Player.Interfaces;
using Player.Inventories;
using Plugins.StanKhrEssentials.EventWrapper.Main;
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
            
            Gear.OnWeaponEquipped.AddListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.AddListener(WeaponRemovedCallback);
        }

        private void OnDestroy()
        {
            Gear.OnWeaponEquipped.RemoveListener(WeaponEquippedCallback);
            Gear.OnWeaponRemoved.RemoveListener(WeaponRemovedCallback);
        }

        #endregion

        #region Methods

        private void ValidateHands()
        {
            if (Gear.WeaponEquipped)
            {
                WeaponEquippedCallback(new Events.WeaponEvent()
                {
                    Weapon = Gear.Weapon
                });
                
                return;
            }
            
            _handRight.SpriteRenderer = _handRightEmpty;
        }

        private void WeaponEquippedCallback(Events.WeaponEvent context)
        {
            _handRight.SpriteRenderer = _handRightWeapon;
            _handRight.SpriteRenderer.sprite = context.Weapon.WeaponHandSprite;
        }

        private void WeaponRemovedCallback(Events.WeaponEvent context)
        {
            _handRight.SpriteRenderer = _handRightEmpty;
        }
        

        #endregion
    }
}