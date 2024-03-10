using Player.Attacks;
using Player.GameStories.Datas;
using Player.Inventories.Interfaces;
using UI.Presenters.Items;
using UI.Utility;
using UI.Utility.Personality;
using UnityEngine;
using WorldGeneration.Interfaces;

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
        public delegate void InventorySlotPresenterEvents(InventorySlotPresenter context);
        public delegate void StringEvents(string context);
        public delegate void StoryEventDataEvents(StoryEventData context);
        public delegate void BoolEvents(bool context);
        public delegate void MeleeAttackDataEvents(MeleeAttackData context);
        public delegate void LevelGeneratorEvents(ILevelGenerator levelGenerator);
        public delegate void StatusPropertyEvents(PersonalityStatusProperty personalityStatusProperty);
        public delegate void Vector3Events(Vector3 context);

        #endregion

    }
}