using System;

namespace Statuses.Interfaces
{
    public interface IStatus
    {
        #region Events

        event Action OnMaxValueChanged;
        event Action OnCurrentValueChanged;

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