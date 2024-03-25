using System.Collections.Generic;
using Miscellaneous.ObjectPooling;
using Props.Interfaces;
using UnityEngine;

namespace Props.Projectiles
{
    public class ProjectileFactory
    {
        #region Constructors

        private ProjectileFactory()
        {
            
        }

        #endregion

        #region Fields

        private static ProjectileFactory _instance;

        private readonly Dictionary<IProjectile, ObjectPoolWrapper> _poolWrappersDictionary = new();

        #endregion

        #region Properties

        private static ProjectileFactory Instance
        {
            get => _instance ??= new ProjectileFactory();
            set => _instance = value;
        }

        #endregion

        #region Methods

        private PooledObject GetProjectileInstance(IProjectile projectilePrefab)
        {
            if (projectilePrefab is not MonoBehaviour)
            {
                return null;
            }

            if (_poolWrappersDictionary.TryGetValue(projectilePrefab, out var pool))
            {
                return pool.Get();
            }

            if (projectilePrefab is not PooledObject pooledObject)
            {
                return null;
            }
            
            var newPool = new ObjectPoolWrapper(pooledObject);
            _poolWrappersDictionary.Add(projectilePrefab, newPool);

            return newPool.Get();
            
            // return Object.Instantiate(monoBehaviour, position, rotation) as IProjectile;
        }

        #endregion
        
        #region Static Methods

        public static void ResetFactory()
        {
            Instance = null;
        }
        
        public static IProjectile SpawnProjectile(IProjectile projectilePrefab, Vector3 position, Quaternion rotation)
        {
            var projectile = Instance.GetProjectileInstance(projectilePrefab);
            
            var transform = projectile.transform;
            transform.position = position;
            transform.rotation = rotation;
            
            return projectile as IProjectile;
        }

        #endregion
    }
}