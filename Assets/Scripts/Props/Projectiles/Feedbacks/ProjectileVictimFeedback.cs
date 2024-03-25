using System;
using Miscellaneous;
using Props.Interfaces;
using UnityEngine;

namespace Props.Projectiles.Feedbacks
{
    public abstract class ProjectileVictimFeedback : MonoBehaviour
    {
        #region Editor Fields

        // [SerializeField] private 

        #endregion

        #region Fields

        private IProjectile _projectile;

        #endregion

        #region Properties

        protected IProjectile Projectile => _projectile ??= GetComponent<IProjectile>();

        #endregion

        #region Unity Callbacks

        protected virtual void OnEnable()
        {
            Projectile.OnVictimFound.AddListener(VictimFoundCallback);
        }

        protected virtual void OnDisable()
        {
            Projectile.OnVictimFound.RemoveListener(VictimFoundCallback);
        }

        #endregion

        #region Methods

        protected abstract void VictimFoundCallback(EventContext.GameObjectEvent context);

        #endregion
    }
}