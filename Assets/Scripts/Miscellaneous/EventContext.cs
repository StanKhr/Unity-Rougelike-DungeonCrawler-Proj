using Player.GameStories.Datas;
using Player.Inventories.Interfaces;
using UI.Presenters.Items;
using UI.Views.Personality;
using UnityEngine;
using WorldGeneration.Interfaces;

namespace Miscellaneous
{
    public static class EventContext
    {
        #region Types
        
        public struct IntEvent
        {
            public int Int { get; set; }
        }
        
        public struct FloatEvent
        {
            public float Float { get; set; }
        }
        
        public struct StringEvent
        {
            public string String { get; set; }
        }
        
        public struct GameObjectEvent
        {
            public GameObject GameObject { get; set; }
        }
        
        public struct Vector3Event
        {
            public Vector3 Vector3 { get; set; }
        }
        
        public struct WeaponEvent
        {
            public IWeapon Weapon { get; set; }
        }
        
        public struct ItemEvent
        {
            public IItem Item { get; set; }
        }

        public struct StoryEpisodeDataEvent
        {
            public StoryEpisodeData StoryEpisodeData { get; set; }
        }

        public struct TriggerEnterEvent
        {
            public Collider Collider { get; set; }
            public Vector3 HitPoint { get; set; }
        }
        
        public struct MeleeAttackEvent
        {
            public IWeapon Weapon { get; set; }
            public float CritChargePercent { get; set; }
            public bool CritApplied { get; set; }
        }
        
        public struct InventorySlotPresenterEvent
        {
            public InventorySlotPresenter InventorySlotPresenter { get; set; }
        }
        
        public struct LevelGeneratorEvent
        {
            public ILevelGenerator LevelGenerator { get; set; }
        }
        
        public struct PersonalityStatusPropertyEvent
        {
            public PersonalityStatusProperty PersonalityStatusProperty { get; set; }
        }

        #endregion
    }
}