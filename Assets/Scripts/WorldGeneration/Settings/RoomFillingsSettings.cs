﻿using System;
using System.Collections.Generic;
using Miscellaneous;
using UnityEngine;
using WorldGeneration.Interfaces;
using WorldGeneration.Utility;

namespace WorldGeneration.Settings
{
    [Serializable]
    [CreateAssetMenu (menuName = "RPG / World Generation / Room Fillings", fileName = "RoomFillings_NEW")]
    public class RoomFillingsSettings : ScriptableObject, IRoomFillingsSettings
    {
        #region Editor Fields

        [SerializeField] private RoomFilling[] _startRooms;
        [SerializeField] private RoomFilling[] _bossRooms;
        [SerializeField] private RoomFilling[] _roomFillings;
        [SerializeField, Range(0f, 1f)] private float _corridorTrashSpawnChance;
        [SerializeField] private GameObject[] _corridorTrashPrefabs;

        #endregion

        #region Fields
        
        private Dictionary<Vector2Int, List<RoomFilling>> _sortedRoomFillings;
        private Dictionary<Vector2Int, List<RoomFilling>> _refillableLists;
        private List<GameObject> _sortedCorridorTrash = new();

        #endregion

        #region Properties

        private Dictionary<Vector2Int, List<RoomFilling>> SortedRoomFillings
        {
            get
            {
                if (_sortedRoomFillings != null)
                {
                    return _sortedRoomFillings;
                }

                _sortedRoomFillings = new();
                _refillableLists = new();
                
                for (int i = 0; i < _roomFillings.Length; i++)
                {
                    var roomSize = _roomFillings[i].GetRoomSize();
                    if (!_sortedRoomFillings.TryGetValue(roomSize, out var fillingsList))
                    {
                        fillingsList = new List<RoomFilling>();
                        _sortedRoomFillings.Add(roomSize, fillingsList);
                        _refillableLists.Add(roomSize, new List<RoomFilling>());
                    }

                    if (fillingsList.Contains(_roomFillings[i]))
                    {
                        continue;
                    }
                
                    fillingsList.Add(_roomFillings[i]);
                }

                return _sortedRoomFillings;
            }
        }

        #endregion

        #region Methods

        public bool TryGetFilling(Vector2Int roomSize, out RoomFilling roomFilling)
        {
            if (!SortedRoomFillings.TryGetValue(roomSize, out var fillingsList))
            {
                var invertedSize = new Vector2Int(roomSize.y, roomSize.x);

                if (!SortedRoomFillings.TryGetValue(invertedSize, out fillingsList))
                {
                    roomFilling = null;
                    return false;
                }
                
                roomFilling = null;
                return false;
            }

            if (fillingsList.Count <= 0)
            {
                roomFilling = null;
                return false;
            }

            var refillableList = _refillableLists[roomSize];
            if (refillableList.Count <= 0)
            {
                refillableList.AddRange(fillingsList);
            }
            
            var randomIndex = Randomizer.RangeInt(0, refillableList.Count);
            roomFilling = refillableList[randomIndex];
            refillableList.RemoveAt(randomIndex);

            return true;
        }

        public RoomFilling GetStartRoomFilling()
        {
            return _startRooms[Randomizer.RangeInt(0, _startRooms.Length)];
        }

        public RoomFilling GetBossRoomFilling()
        {
            return _bossRooms[Randomizer.RangeInt(0, _bossRooms.Length)];
        }

        public GameObject GetCorridorTrash()
        {
            if (!Randomizer.ComparePercent(_corridorTrashSpawnChance))
            {
                return null;
            }

            if (_sortedCorridorTrash.Count <= 0)
            {
                _sortedCorridorTrash.AddRange(_corridorTrashPrefabs);
            }

            return _sortedCorridorTrash.GetRandomElementAndRemove();
        }

        #endregion
    }
}