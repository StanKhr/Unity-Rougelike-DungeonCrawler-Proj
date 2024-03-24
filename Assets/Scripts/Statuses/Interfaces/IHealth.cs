using System;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;

namespace Statuses.Interfaces
{
    public interface IHealth : IStatus
    {
        #region Events

        IEvent OnDied { get; }
        IEvent OnResurrected { get; }

        #endregion
        
        #region Properties

        bool Alive => CurrentValue > 0f;

        #endregion

        #region Methods
        
        bool TryHeal(float healValue);
        void Resurrect();
        void Kill();

        #endregion
    }
}