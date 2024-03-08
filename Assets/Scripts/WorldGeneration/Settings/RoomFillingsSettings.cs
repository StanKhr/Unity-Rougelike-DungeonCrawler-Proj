using System;
using System.Collections.Generic;
using UnityEngine;
using WorldGeneration.Utility;
using Random = UnityEngine.Random;

namespace WorldGeneration.Settings
{
    [Serializable]
    [CreateAssetMenu (menuName = "RPG / World Generation / Room Fillings", fileName = "RoomFillings_NEW")]
    public class RoomFillingsSettings : ScriptableObject
    {
        #region Editor Fields

        [SerializeField] private RoomFilling[] _roomFillings;

        #endregion

        #region Fields
        
        private Dictionary<Vector2Int, List<RoomFilling>> _sortedRoomFillings;

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
                
                for (int i = 0; i < _roomFillings.Length; i++)
                {
                    var roomSize = _roomFillings[i].GetRoomSize();
                    if (!_sortedRoomFillings.TryGetValue(roomSize, out var fillingsList))
                    {
                        fillingsList = new List<RoomFilling>();
                        _sortedRoomFillings.Add(roomSize, fillingsList);
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
                roomFilling = null;
                return false;
            }

            if (fillingsList.Count <= 0)
            {
                roomFilling = null;
                return false;
            }
            
            var randomIndex = Random.Range(0, fillingsList.Count);
            roomFilling = fillingsList[randomIndex];

            return true;
        }
        
        #endregion
    }
}