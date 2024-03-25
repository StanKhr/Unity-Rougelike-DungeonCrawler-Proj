using System;
using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Props.Projectiles.Components
{
    public class ProjectileSimpleDamageable : MonoBehaviour, IDamageable
    {
        #region Events

        public IContextEvent<EventContext.FloatEvent> OnDamaged { get; } =
            EventFactory.CreateContextEvent<EventContext.FloatEvent>();

        #endregion

        #region Fields

        private bool _damaged;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            _damaged = false;
        }

        #endregion

        #region Methods

        public bool TryApplyDamage(Damage damage)
        {
            if (_damaged)
            {
                return false;
            }

            _damaged = true;
            
            OnDamaged?.NotifyListeners(new EventContext.FloatEvent()
            {
                Float = 1f
            });

            return true;
        }

        #endregion
    }
}