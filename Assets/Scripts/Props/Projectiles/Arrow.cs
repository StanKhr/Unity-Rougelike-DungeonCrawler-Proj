using Props.Interfaces;
using Statuses.Datas;
using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;

namespace Props.Projectiles
{
    public class Arrow : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private ProjectileRigidbody _projectileRigidbody;
        [SerializeField] private Damage _damage;
        [SerializeField] private Health _arrowHealth;

        #endregion

        #region Properties

        private IProjectile Projectile => _projectileRigidbody;
        private IHealth ArrowHealth => _arrowHealth;
        
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
                damageable.TryApplyDamage(_damage);
            }
            
            _arrowHealth.Kill();
        }

        #endregion
    }
}