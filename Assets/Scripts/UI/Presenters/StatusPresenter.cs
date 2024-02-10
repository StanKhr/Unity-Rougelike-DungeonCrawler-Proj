using System;
using Cysharp.Threading.Tasks;
using Statuses.Interfaces;
using Statuses.Main;
using TMPro;
using UI.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presenters
{
    public class StatusPresenter : MonoBehaviour
    {
        #region Constants

        private const float DelayTime = 1.5f;
        private const float AnimationSpeed = 0.25f;

        #endregion
        
        #region Editor Fields

        [SerializeField] private Status _status;

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

        private async void OnEnable()
        {
            await UniTask.Yield();
            
            Status.OnCurrentValueChanged += CurrentValueChangedCallback;
            Status.OnMaxValueChanged += MaxValueChangedCallback;

            SetDefaultValues();
        }

        private void OnDisable()
        {
            Status.OnCurrentValueChanged -= CurrentValueChangedCallback;
            Status.OnMaxValueChanged -= MaxValueChangedCallback;
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

            MaskFill = Mathf.MoveTowards(MaskFill, Status.Percent, Time.deltaTime * AnimationSpeed);
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
            _delay = DelayTime;
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