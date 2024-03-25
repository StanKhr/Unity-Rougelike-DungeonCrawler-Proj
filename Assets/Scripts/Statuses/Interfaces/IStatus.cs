using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;

namespace Statuses.Interfaces
{
    public interface IStatus
    {
        #region Events

        IEvent OnMaxValueChanged { get; }
        IEvent OnCurrentValueChanged { get; }

        #endregion
        
        #region Properties

        float MaxValue { get; }
        float CurrentValue { get; }
        float Percent => CurrentValue / MaxValue;

        #endregion

        #region Methods

        void SetValue(float value);
        void SetMaxValue(float maxValue);

        #endregion

        #region Interface Methods

        void AddValue(float value)
        {
            SetValue(CurrentValue + value);
        }

        void SubtractValue(float value)
        {
            SetValue(CurrentValue - value);
        }

        #endregion
    }
}