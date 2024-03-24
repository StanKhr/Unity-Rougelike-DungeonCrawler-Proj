﻿using Miscellaneous;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;

namespace Props.Interfaces
{
    public interface IProjectile
    {
        #region Events

        IContextEvent<Events.GameObjectEvent> OnVictimFound { get; }

        #endregion
        
        #region Methods

        void Launch();
        void Launch(Vector3 direction);
        void Launch(Vector3 position, Vector3 direction);

        #endregion
    }
}