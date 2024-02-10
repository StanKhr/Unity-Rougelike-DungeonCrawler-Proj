using System;
using Statuses.Interfaces;
using UnityEngine;

namespace Statuses.Main
{
    public abstract class Status : MonoBehaviour, IStatus
    {
        #region Constants

        private const float MinValue = 0f;

        #endregion
        
        #region Events

        public event Action OnMaxValueChanged;
        public event Action OnCurrentValueChanged;

        #endregion
        
        #region Editor Fields

        [SerializeField] private float _baseValue = 100;

        #endregion

        #region Fields

        private float _maxValue;
        private float _currentValue;

        #endregion

        #region Properties

        public float MaxValue
        {
            get => _maxValue;
            private set
            {
                var percent = (this as IStatus).Percent;
                _maxValue = value;
                CurrentValue = MaxValue * percent;
                
                OnMaxValueChanged?.Invoke();
            }
        }

        public float CurrentValue
        {
            get => _currentValue;
            private set
            {
                _currentValue = Mathf.Clamp(value, MinValue, MaxValue);
                
                OnCurrentValueChanged?.Invoke();
            }
        }

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            SetMaxValue(_baseValue);
        }

        #endregion

        #region Methods

        public void SetValue(float value)
        {
            CurrentValue = value;
        }

        public void SetMaxValue(float maxValue)
        {
            MaxValue = maxValue;
        }

        #endregion
    }
}