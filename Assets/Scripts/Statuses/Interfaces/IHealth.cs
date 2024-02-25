namespace Statuses.Interfaces
{
    public interface IHealth : IStatus
    {
        #region Properties

        bool Alive { get; }

        #endregion

        #region Methods
        
        bool TryHeal(float healValue);

        #endregion
    }
}