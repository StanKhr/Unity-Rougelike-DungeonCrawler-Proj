using UnityEngine;
using WorldGeneration.Enums;

namespace WorldGeneration.Interfaces
{
    public interface ISpawnableEnemies
    {
        #region Methods

        GameObject GetEnemy(EnemyType type);
        GameObject GetBoss();

        #endregion
    }
}