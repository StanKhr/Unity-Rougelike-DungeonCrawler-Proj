using Miscellaneous.CustomEvents.Contexts;
using Miscellaneous.CustomEvents.Events;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using UnityEngine;

namespace Player.Inventories
{
    public class Gear : MonoBehaviour, IGear
    {
        #region Editor Fields

        [SerializeField] private Inventory _inventory;

        #endregion

        #region Events

        public ValueEvent<EventContext.WeaponEvent> OnWeaponEquipped { get; } = new ();

        public ValueEvent<EventContext.WeaponEvent> OnWeaponRemoved { get; } = new ();

        #endregion

        #region Fields

        private IWeapon _weapon;
        private IInventory Inventory => _inventory;

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
                    OnWeaponEquipped?.Invoke(new EventContext.WeaponEvent
                    {
                        Weapon = Weapon
                    });
                    return;
                }

                OnWeaponRemoved?.Invoke(new EventContext.WeaponEvent()
                {
                    Weapon = prevWeapon
                });
            }
        }

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Inventory.OnItemDropped += ItemDroppedCallback;
        }

        private void OnDestroy()
        {
            Inventory.OnItemDropped -= ItemDroppedCallback;
        }

        #endregion

        #region Methods

        private void ItemDroppedCallback(IItem context)
        {
            if (context is IWeapon weapon)
            {
                CheckDroppedWeapon(weapon);
            }
        }

        private void CheckDroppedWeapon(IWeapon weapon)
        {
            if (Weapon != weapon)
            {
                return;
            }

            if (Inventory.HasItem(weapon, out _))
            {
                return;
            }

            Weapon = null;
        }

        #endregion
    }
}