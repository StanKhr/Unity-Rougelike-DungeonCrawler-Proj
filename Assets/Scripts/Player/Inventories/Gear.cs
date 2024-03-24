using Miscellaneous;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;

namespace Player.Inventories
{
    public class Gear : MonoBehaviour, IGear
    {
        #region Editor Fields

        [SerializeField] private Inventory _inventory;

        #endregion

        #region Events

        public ContextEvent<Events.WeaponEvent> OnWeaponEquipped { get; } = new ();

        public ContextEvent<Events.WeaponEvent> OnWeaponRemoved { get; } = new ();

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
                    OnWeaponEquipped?.NotifyListeners(new Events.WeaponEvent
                    {
                        Weapon = Weapon
                    });
                    return;
                }

                OnWeaponRemoved?.NotifyListeners(new Events.WeaponEvent()
                {
                    Weapon = prevWeapon
                });
            }
        }

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Inventory.OnItemDropped.AddListener(ItemDroppedCallback);
        }

        private void OnDestroy()
        {
            Inventory.OnItemDropped.RemoveListener(ItemDroppedCallback);
        }

        #endregion

        #region Methods

        private void ItemDroppedCallback(Events.ItemEvent context)
        {
            if (context.Item is IWeapon weapon)
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