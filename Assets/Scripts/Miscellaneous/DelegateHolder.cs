using Player.Inventories.Interfaces;
using UnityEngine;

namespace Miscellaneous
{
    public static class DelegateHolder
    {
        #region Delegates

        public delegate void GameObjectEvents(GameObject context);
        public delegate void ColliderEvents(Collider context);
        public delegate void FloatEvents(float context);
        public delegate void IntEvents(int context);
        public delegate void ItemEvents(IItem context);
        public delegate void WeaponEvents(IWeapon context);

        #endregion
    }
}