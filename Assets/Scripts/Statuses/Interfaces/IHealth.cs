using System;

namespace Statuses.Interfaces
{
    public interface IHealth : IStatus
    {
        #region Events

        event Action OnDied;
        event Action OnResurrected;

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