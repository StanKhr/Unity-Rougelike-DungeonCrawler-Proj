using System;
using Miscellaneous;
using Miscellaneous.EventWrapper.Events;
using Miscellaneous.EventWrapper.Interfaces;
using Miscellaneous.EventWrapper.Main;
using NPCs.Interfaces;
using Statuses.Datas;
using Statuses.Enums;
using Statuses.Interfaces;
using UnityEngine;

namespace NPCs.Components
{
    public class EnemyAttackMelee : MonoBehaviour, IEnemyAttack
    {
        #region Constants

        private static readonly DamageType DamageType = DamageType.MeleeBonk;
        private const string PlayerTag = "Player";
        
        #endregion
        
        #region Events

        public static IContextEvent<Events.Vector3Event> OnAttackAtPointPerformed { get; } =
            new ContextEvent<Events.Vector3Event>();

        #endregion
        
        #region Editor Fields

        [field: SerializeField] public float AttackChargeTime { get; private set; } = 0.6f;
        [field: SerializeField] public float AttackReleaseTime { get; private set; } = 1.2f;
        [field: SerializeField] public float MinAttackDistance { get; private set; } = 3f;
        [SerializeField] private float _attackRadius = 4f;
        [SerializeField] private float _damageValue = 10f;
        [SerializeField] private LayerMask _damageableLayers;
        
        #endregion

        #region Fields
        
        private static readonly Collider[] ScanResult = new Collider[20];

        #endregion

        #region Unity Callbacks

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + transform.forward, _attackRadius);
        }
#endif

        #endregion
        
        #region Methods

        public void PerformAttack(Vector3 victimPosition)
        {
            if (_attackRadius <= 0f)
            {
                return;
            }
            
            var position = transform.position;
            var direction = (victimPosition - position).normalized;
            var attackPosition = position + direction;
            
            OnAttackAtPointPerformed?.NotifyListeners(new Events.Vector3Event
            {
                Vector3 = attackPosition
            });

            Array.Clear(ScanResult, 0, ScanResult.Length);
            if (Physics.OverlapSphereNonAlloc(attackPosition, _attackRadius, ScanResult, _damageableLayers) <= 0)
            {
                return;
            }

            foreach (var scannedCollider in ScanResult)
            {
                if (!scannedCollider)
                {
                    continue;
                }

                if (!scannedCollider.gameObject.CompareTag(PlayerTag))
                {
                    continue;
                }

                if (scannedCollider.gameObject.TryGetComponent<IDamageable>(out var damageable))
                {
                    var damage = new Damage(_damageValue, DamageType, gameObject);
                    damageable.TryApplyDamage(damage);
                }
                
                return;
            }
        }

        #endregion
    }
}