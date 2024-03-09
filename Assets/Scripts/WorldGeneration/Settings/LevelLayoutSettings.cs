using System;
using Miscellaneous;
using UnityEngine;
using WorldGeneration.Data;
using WorldGeneration.Interfaces;

namespace WorldGeneration.Settings
{
    [Serializable]
    [CreateAssetMenu (menuName = "RPG / World Generation / Level Layout", fileName = "LevelLayout_NEW")]
    public class LevelLayoutSettings : ScriptableObject, ILevelLayoutSettings
    {
        #region Editor Fields

        [SerializeField] private RoomData _startRoom;
        [SerializeField] private RoomData _bossRoom;
        [SerializeField] private RoomData[] _randomRooms;
        [SerializeField] private int _corridorMinSteps = 1;
        [SerializeField] private int _corridorMaxSteps = 2;
        [SerializeField, Min(2)] private int _requiredRoomsAmount = 5;
        [SerializeField] private int _extraRoomsMaxAmount = 5;

        #endregion

        #region Methods

        public int GetExpectedRoomsAmount()
        {
            return _requiredRoomsAmount + Randomizer.RangeInt(0, _extraRoomsMaxAmount);
        }

        public int GetCorridorSteps()
        {
            return Randomizer.RangeInt(_corridorMinSteps, _corridorMaxSteps);
        }

        public RoomData GetRandomRoom()
        {
            return _randomRooms[Randomizer.RangeInt(0, _randomRooms.Length)];
        }

        public RoomData GetStartRoom()
        {
            return _startRoom;
        }

        public RoomData GetBossRoom()
        {
            return _bossRoom;
        }

        #endregion
    }
}