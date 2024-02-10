using System;
using Abilities.Interfaces;
using Abilities.Triggers;
using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Props
{
    public class GroundTrap : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private ColliderTrigger _colliderTrigger;
        [SerializeField] private Damage _damage;

        #endregion

        #region Properties

        private IColliderTrigger ColliderTrigger => _colliderTrigger;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            ColliderTrigger.OnEntered += EnteredCallback;
        }

        private void OnDisable()
        {
            ColliderTrigger.OnEntered -= EnteredCallback;
        }

        #endregion

        #region Methods


        private void EnteredCallback(Collider obj)
        {
            if (!obj.TryGetComponent<IDamageable>(out var damageable))
            {
                return;
            }
            
            damageable.ApplyDamage(_damage);
        }

        #endregion
    }
}