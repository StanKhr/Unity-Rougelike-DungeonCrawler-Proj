using System;
using UnityEngine;
using WorldGeneration.Interfaces;

namespace WorldGeneration.Settings
{
    [Serializable]
    [CreateAssetMenu (menuName = "RPG / World Generation / Level Tiles", fileName = "LevelTiles_NEW")]
    public class LevelTiles : ScriptableObject, ILevelTiles
    {
        #region Editor Fields

        [SerializeField] private GameObject _wallPrefab;
        [SerializeField] private GameObject _floorPrefab;

        #endregion

        #region Methods


        public GameObject GetWall()
        {
            return _wallPrefab;
        }

        public GameObject GetFloor()
        {
            return _floorPrefab;
        }

        #endregion
    }
}