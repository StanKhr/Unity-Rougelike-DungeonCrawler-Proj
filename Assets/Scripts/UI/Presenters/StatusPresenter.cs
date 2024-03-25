using System;
using Plugins.StanKhrEssentials.Scripts.UI;
using Statuses.Interfaces;
using Statuses.Main;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presenters
{
    public class StatusPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Status _status;
        [SerializeField] private float _delayTime = 1.5f;
        [SerializeField] private float _animationSpeed = 0.25f;
        
        [Header("Views")]
        [SerializeField] private TextMeshProUGUI _valueText;
        [SerializeField] private TextMeshProUGUI _percentText;
        [SerializeField] private Image _maskSlider;
        [SerializeField] private Image _darkerSlider;

        #endregion

        #region Properties

        private IStatus Status => _status;

        #endregion

        #region Fields

        private float _delay;

        #endregion

        #region Properties

        private float MaskFill
        {
            get => _maskSlider.fillAmount;
            set
            {
                if (Math.Abs(MaskFill - value) < 0f)
                {
                    return;
                }
                
                _maskSlider.fillAmount = value;
            }
        }

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Status.OnCurrentValueChanged.AddListener(CurrentValueChangedCallback);
            Status.OnMaxValueChanged.AddListener(MaxValueChangedCallback);

            SetDefaultValues();
        }

        private void OnDestroy()
        {
            Status.OnCurrentValueChanged.RemoveListener(CurrentValueChangedCallback);
            Status.OnMaxValueChanged.RemoveListener(MaxValueChangedCallback);
        }

        private void Update()
        {
            if (Status == null)
            {
                return;
            }
            
            if (_delay > 0f)
            {
                _delay -= Time.deltaTime;
                return;
            }

            if (_animationSpeed <= 0f)
            {
                MaskFill = Status.Percent;
                return;
            }

            MaskFill = Mathf.MoveTowards(MaskFill, Status.Percent, Time.deltaTime * _animationSpeed);
        }

        #endregion

        #region Methods

        private void SetDefaultValues()
        {
            SetMaskFill(Status.Percent);
            SetDarkFill(Status.Percent);
            UpdateText();
        }
        
        private void CurrentValueChangedCallback()
        {
            UpdateText();
            _delay = _delayTime;
            SetDarkFill(Status.Percent);
        }
        
        private void MaxValueChangedCallback()
        {
            
        }

        private void UpdateText()
        {
            _percentText.SetTextSmart($"{(Status.Percent * 100).ToString("F0")}%");
            _valueText.SetTextSmart($"{Status.CurrentValue.ToString("F0")}");
        }

        private void SetMaskFill(float value)
        {
            MaskFill = value;
        }

        private void SetDarkFill(float value)
        {
            _darkerSlider.fillAmount = 1 - value;
        }

        #endregion
    }
}