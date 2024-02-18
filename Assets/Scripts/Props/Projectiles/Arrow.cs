using System;
using Props.Interfaces;
using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Props.Projectiles
{
    public class Arrow : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private ProjectileRigidbody _projectileRigidbody;
        [SerializeField] private Damage _damage;

        #endregion

        #region Properties

        private IProjectile Projectile => _projectileRigidbody;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            Projectile.OnVictimFound += VictimFoundCallback;
        }

        private void OnDisable()
        {
            Projectile.OnVictimFound -= VictimFoundCallback;
        }

        #endregion

        #region Methods
        
        private void VictimFoundCallback(GameObject context)
        {
            if (context.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(_damage);
            }
            
            Destroy(gameObject);
        }

        #endregion
    }
}