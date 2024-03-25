using System;
using Miscellaneous;
using Props.Interfaces;
using UnityEngine;

namespace Props.Projectiles.Feedbacks
{
    public abstract class ProjectileEventsListener : MonoBehaviour
    {
        #region Editor Fields

        // [SerializeField] private 

        #endregion

        #region Fields

        private IProjectile _projectile;

        #endregion

        #region Properties

        protected IProjectile Projectile => _projectile ??= GetComponent<IProjectile>();
        protected virtual bool ListenVictimFoundEvent { get; } = false;
        protected virtual bool ListenDestroyEvent { get; } = false;

        #endregion

        #region Unity Callbacks

        protected virtual void OnEnable()
        {
            if (ListenVictimFoundEvent)
            {
                Projectile.OnVictimFound.AddListener(VictimFoundCallback);
            }

            if (ListenDestroyEvent)
            {
                Projectile.OnDestroyed.AddListener(DestroyedCallback);
            }
        }

        protected virtual void OnDisable()
        {
            if (ListenVictimFoundEvent)
            {
                Projectile.OnVictimFound.RemoveListener(VictimFoundCallback);
            }

            if (ListenDestroyEvent)
            {
                Projectile.OnDestroyed.RemoveListener(DestroyedCallback);
            }
        }

        #endregion

        #region Methods

        protected virtual void VictimFoundCallback(EventContext.GameObjectEvent context)
        {
            
        }

        protected virtual void DestroyedCallback()
        {
            
        }

        #endregion
    }
}