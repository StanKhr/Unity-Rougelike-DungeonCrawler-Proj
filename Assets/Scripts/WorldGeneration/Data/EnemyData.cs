using System;
using UnityEngine;
using WorldGeneration.Enums;

namespace WorldGeneration.Data
{
    [Serializable]
    public struct EnemyData
    {
        #region Editor Fields

        [field: SerializeField] public EnemyType EnemyType { get; set; }
        [field: SerializeField] public GameObject Prefab { get; set; }
        [field: SerializeField] public int SpawnWeight { get; set; }

        #endregion
    }
}