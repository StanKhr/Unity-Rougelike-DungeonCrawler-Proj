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

        #endregion

        #region Properties

        private static ProjectileFactory Instance
        {
            get => _instance ??= new ProjectileFactory();
            set => _instance = value;
        }

        #endregion

        #region Methods

        private IProjectile GetProjectileInstance(IProjectile projectilePrefab, Vector3 position, Quaternion rotation)
        {
            if (projectilePrefab is not MonoBehaviour monoBehaviour)
            {
                return null;
            }

            return Object.Instantiate(monoBehaviour, position, rotation) as IProjectile;
        }

        #endregion
        
        #region Static Methods

        public static void ResetFactory()
        {
            Instance = null;
        }
        
        public static IProjectile SpawnProjectile(IProjectile projectilePrefab, Vector3 position, Quaternion rotation)
        {
            return Instance.GetProjectileInstance(projectilePrefab, position, rotation);
        }

        #endregion
    }
}