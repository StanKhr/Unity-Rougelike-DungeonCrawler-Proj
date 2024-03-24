using System;
using System.Collections.Generic;
using Miscellaneous;
using Plugins.KaimiraGames;
using UnityEngine;
using WorldGeneration.Data;
using WorldGeneration.Enums;
using WorldGeneration.Interfaces;

namespace WorldGeneration.Settings
{
    [Serializable]
    [CreateAssetMenu(menuName = "RPG / World Generation / Spawnable Enemies", fileName = "SpawnableEnemies_NEW")]
    public class SpawnableEnemies : ScriptableObject, ISpawnableEnemies
    {
        #region Editor Fields

        [SerializeField] private EnemyData[] _enemies;
        [SerializeField] private GameObject _bossPrefab;

        #endregion

        #region Fields

        private Dictionary<EnemyType, WeightedList<GameObject>> _sortedEnemies;

        #endregion

        #region Properties

        private Dictionary<EnemyType, WeightedList<GameObject>> SortedEnemies
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
                    if (_enemies[i].SpawnWeight <= 0)
                    {
                        LogWriter.DevelopmentLog($"Enemy {_enemies[i].ToString()}: spawn weight is 0 or less.",
                            LogType.Warning);
                        continue;
                    }

                    var type = _enemies[i].EnemyType;
                    if (!_sortedEnemies.TryGetValue(type, out var enemiesList))
                    {
                        enemiesList = new WeightedList<GameObject>();
                        _sortedEnemies.Add(type, enemiesList);
                    }

                    enemiesList.Add(_enemies[i].Prefab, _enemies[i].SpawnWeight);
                }

                return _sortedEnemies;
            }
        }

        #endregion

        #region Methods

        public GameObject GetEnemy(EnemyType type)
        {
            if (!SortedEnemies.TryGetValue(type, out var list))
            {
                return null;
            }

            return list.Next();
        }

        public GameObject GetBoss()
        {
            return _bossPrefab;
        }

        #endregion
    }
}