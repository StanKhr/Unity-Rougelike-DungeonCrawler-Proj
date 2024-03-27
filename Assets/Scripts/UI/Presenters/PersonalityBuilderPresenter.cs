using System;
using System.Collections.Generic;
using Miscellaneous;
using Player.Enums;
using Player.Interfaces;
using Plugins.StanKhrEssentials.Scripts.UI;
using Plugins.StanKhrEssentials.Scripts.UI.Views;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Presenters
{
    public class PersonalityBuilderPresenter : MonoBehaviour
    {
        #region Constants

        private const int StatusValueMax = 290;
        private const int StatusValueStep = 5;
        private const int DefaultStatusValue = 100;
        private const int StatusesCount = 3;

        private static readonly Color ValidColor = Color.green;
        private static readonly Color InvalidColor = Color.red;

        #endregion
        
        #region Editor Fields

        [SerializeField] private LocalizedString _genderLocaleMale;
        [SerializeField] private LocalizedString _genderLocaleFemale;

        [Header("Views")]
        [SerializeField] private OptionSelector _genderSelector;
        [SerializeField] private OptionSelector _healthSelector;
        [SerializeField] private OptionSelector _staminaSelector;
        [SerializeField] private OptionSelector _manaSelector;
        [SerializeField] private TextMeshProUGUI _statusesDifferenceText;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            UpdateGenderSelector();
        }

        private void Start()
        {
            InitializeStatusSelectors();

            _healthSelector.OnSelectedOptionUpdated.AddListener(RecalculateSum);
            _staminaSelector.OnSelectedOptionUpdated.AddListener(RecalculateSum);
            _manaSelector.OnSelectedOptionUpdated.AddListener(RecalculateSum);
        }

        private void OnDestroy()
        {
            _healthSelector.OnSelectedOptionUpdated.RemoveListener(RecalculateSum);
            _staminaSelector.OnSelectedOptionUpdated.RemoveListener(RecalculateSum);
            _manaSelector.OnSelectedOptionUpdated.RemoveListener(RecalculateSum);
        }

        #endregion
        
        #region Methods

        private void RecalculateSum()
        {
            var optionsSum = _healthSelector.SelectedOptionIndex;
            optionsSum += _staminaSelector.SelectedOptionIndex;
            optionsSum += _manaSelector.SelectedOptionIndex;

            optionsSum += StatusesCount;
            optionsSum *= StatusValueStep;
            optionsSum = StatusesCount * DefaultStatusValue - optionsSum;

            var text = optionsSum > 0 ? $"+{optionsSum.ToString()}" : optionsSum.ToString();
            _statusesDifferenceText.SetTextSmart(text);
            _statusesDifferenceText.SetColorSmart(optionsSum == 0 ? ValidColor : InvalidColor);
        }

        private void UpdateGenderSelector()
        {
            var genderOptions = new string[2]
            {
                _genderLocaleMale.GetLocalizedString(),
                _genderLocaleFemale.GetLocalizedString()
            };
            
            _genderSelector.OverrideOptions(genderOptions);
            _genderSelector.SelectOption(Randomizer.CoinFlip() ? 0 : 1);
        }

        private void InitializeStatusSelectors()
        {
            var statusOptions = new List<string>();
            int defaultValue = 0;

            var currentStatusValue = StatusValueStep;
            var index = 0;
            while (currentStatusValue <= StatusValueMax)
            {
                statusOptions.Add(currentStatusValue.ToString());

                if (DefaultStatusValue == currentStatusValue)
                {
                    defaultValue = index;
                }
                
                index++;
                currentStatusValue += StatusValueStep;
            }
            
            _healthSelector.OverrideOptions(statusOptions);
            _healthSelector.SelectOption(defaultValue);
            
            _staminaSelector.OverrideOptions(statusOptions);
            _staminaSelector.SelectOption(defaultValue);
            
            _manaSelector.OverrideOptions(statusOptions);
            _manaSelector.SelectOption(defaultValue);
        }
        
        public bool TryConfirmPersonality()
        {
            var gender = (GenderType) _genderSelector.SelectedOptionIndex;
            var health = _healthSelector.SelectedOptionIndex * StatusValueStep + StatusValueStep;
            var stamina = _staminaSelector.SelectedOptionIndex * StatusValueStep + StatusValueStep;
            var mana = _manaSelector.SelectedOptionIndex * StatusValueStep + StatusValueStep;

            if (!Personality.TryCreatePersonality(gender, health, stamina, mana, out var personality))
            {
                return false;
            }

            Personality.Active = personality;
            return true;
        }

        #endregion
    }
}