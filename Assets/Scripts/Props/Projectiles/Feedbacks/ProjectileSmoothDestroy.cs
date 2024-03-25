using Miscellaneous;
using UnityEngine;

namespace Props.Projectiles.Feedbacks
{
    public class ProjectileSmoothDestroy : ProjectileVictimFeedback
    {
        #region Editor Fields

        [SerializeField] private float _deathSecondsDelay = 0.24f;

        #endregion
        
        #region Methods

        protected override void VictimFoundCallback(EventContext.GameObjectEvent context)
        {
            Projectile.SelfDestroyTimer.TryInterrupt();
            Projectile.SelfDestroyTimer.TryStartCustomTime(_deathSecondsDelay);
        }

        #endregion
    }
}