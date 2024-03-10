namespace Statuses.Interfaces
{
    public interface IStamina : IStatus
    {
        #region Methods

        bool TryDecrease(float value);
        void Tick(float deltaTime);

        #endregion
    }
}