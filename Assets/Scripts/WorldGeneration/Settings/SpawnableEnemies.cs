using System;
using System.Collections.Generic;
using UnityEngine;
using WorldGeneration.Data;
using WorldGeneration.Enums;
using WorldGeneration.Interfaces;

namespace WorldGeneration.Settings
{
    [Serializable]
    [CreateAssetMenu (menuName = "RPG / World Generation / Spawnable Enemies", fileName = "SpawnableEnemies_NEW")]
    public class SpawnableEnemies : ScriptableObject, ISpawnableEnemies
    {
        #region Editor Fields

        [SerializeField] private EnemyData[] _enemies;
        [SerializeField] private GameObject _bossPrefab;
        
        #endregion

        #region Fields

        private Dictionary<EnemyType, List<GameObject>> _sortedEnemies;

        #endregion
        
        #region Properties

        private Dictionary<EnemyType, List<GameObject>> SortedEnemies
        {
            get
            {
                if (_sortedEnemies != null)
                {
                    return _sortedEnemies;
                }

                _sortedEnemies = new();

                for (int i = 0; i < _enemies.Length; i++)
                {
                    var type = _enemies[i].EnemyType;
                    if (!_sortedEnemies.TryGetValue(type, out var enemiesList))
                    {
                        enemiesList = new List<GameObject>();
                        _sortedEnemies.Add(type, enemiesList);
                    }
                    
                    enemiesList.Add(_enemies[i].Prefab);
                }

                return _sortedEnemies;
            }
        }

        #endregion
        
        #region Methods


        public GameObject GetEnemy(EnemyType type)
        {
            return null;
        }

        public GameObject GetBoss()
        {
            return _bossPrefab;
        }

        #endregion
    }
}