using Miscellaneous;
using Player.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using UnityEngine;

namespace Props.Interfaces
{
    public interface IProjectile
    {
        #region Events

        IContextEvent<EventContext.GameObjectEvent> OnVictimFound { get; }

        #endregion

        #region Properties

        ITimer SelfDestroyTimer { get; }

        #endregion
        
        #region Methods

        void Launch();
        void Launch(Vector3 direction);
        void Launch(Vector3 position, Vector3 direction);

        #endregion
    }
}