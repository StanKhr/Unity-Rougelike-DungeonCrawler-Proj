using Miscellaneous;
using UnityEngine;

namespace Props.Projectiles.Feedbacks
{
    public class ProjectileSmoothDestroy : ProjectileEventsListener
    {
        #region Editor Fields

        [SerializeField] private float _deathSecondsDelay = 0.24f;

        #endregion

        #region Properties

        protected override bool ListenDestroyEvent { get; } = true;

        #endregion
        
        #region Methods

        protected override void DestroyedCallback()
        {
            Projectile.SelfDestroyTimer.TryInterrupt();
            Projectile.SelfDestroyTimer.TryStartCustomTime(_deathSecondsDelay);
        }

        #endregion
    }
}