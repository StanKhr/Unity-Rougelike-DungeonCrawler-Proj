namespace DynamicValues.Interfaces
{
    public interface IHealth
    {
        #region Properties

        float MaxHealth { get; }
        float CurrentHealth { get; }

        #endregion
    }
}