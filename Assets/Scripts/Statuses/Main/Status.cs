﻿using System;
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

        [SerializeField] private float _baseValue;

        #endregion

        #region Fields

        private float _maxValue;
        private float _currentValue = 0f;

        #endregion

        #region Properties

        protected virtual bool EventNotificationEnabled => true;
        public float MaxValue
        {
            get => _maxValue;
            protected set
            {
                var percent = (this as IStatus).Percent;
                _maxValue = Mathf.Max(value, 0f);
                if (CurrentValue > 0f)
                {
                    CurrentValue = MaxValue * percent;
                }

                if (!EventNotificationEnabled)
                {
                    return;
                }
                
                OnMaxValueChanged?.Invoke();
            }
        }

        public virtual float CurrentValue
        {
            get => _currentValue;
            protected set
            {
                _currentValue = Mathf.Clamp(value, MinValue, MaxValue);

                if (!EventNotificationEnabled)
                {
                    return;
                }
                
                OnCurrentValueChanged?.Invoke();
            }
        }

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            SetMaxValue(GetBaseValue());
            CurrentValue = MaxValue;
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

        protected virtual float GetBaseValue()
        {
            return _baseValue;
        }

        #endregion
    }
}