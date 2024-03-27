using System;
using System.Collections.Generic;
using Audio.Interfaces;
using Plugins.StanKhrEssentials.Scripts.UI.Views;
using Settings;
using Settings.Audio;
using Settings.Enums;
using UnityEngine;

namespace UI.Presenters
{
    public class AudioVolumePresenter : MonoBehaviour
    {
        #region Constants

        private const float MinVolumeValue = 0.0f;
        private const float MaxVolumeValue = 1.0f;
        private const int InvalidOptionValue = -1;

        #endregion
        
        #region Editor Fields

        [SerializeField] private AudioChannelType _audioChannelType;
        [SerializeField, Range(0f, 1f)] private float _changeValueStep = 0.05f;

        [Header("Views")]
        [SerializeField] private OptionSelector _optionSelector;

        #endregion

        #region Fields

        private readonly Dictionary<int, float> _volumeOptionsDictionary = new();

        #endregion

        #region Properties

        private IAudioVolume AudioVolume => GameSettings.Instance.GetVolumeFromChannelType(_audioChannelType);

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            var optionsCount = Mathf.RoundToInt(1 / _changeValueStep) + 1;
            var selectorOptions = new string[optionsCount];
            
            var currentVolume = AudioVolume.Volume;
            var currentlySelectedOption = InvalidOptionValue;
            
            for (int i = 0; i < optionsCount; i++)
            {
                float volumeValue;
                if (i > 0 && i < optionsCount + 1)
                {
                    volumeValue = _changeValueStep * i;
                }
                else
                {
                    volumeValue = i == 0 ? MinVolumeValue : MaxVolumeValue;
                }

                if (Math.Abs(currentVolume - volumeValue) <= 0f)
                {
                    currentlySelectedOption = i;
                }
                
                _volumeOptionsDictionary.TryAdd(i, volumeValue);
                selectorOptions[i] = volumeValue.ToString("P0");
            }
            
            _optionSelector.OverrideOptions(selectorOptions);

            _optionSelector.NotifyListeners = false;
            _optionSelector.SelectOption(currentlySelectedOption != InvalidOptionValue ? currentlySelectedOption : 0);
            _optionSelector.NotifyListeners = true;

            _optionSelector.OnSelectedOptionUpdated.AddListener(SelectedOptionUpdatedCallback);
        }

        private void OnDestroy()
        {
            _optionSelector.OnSelectedOptionUpdated.RemoveListener(SelectedOptionUpdatedCallback);
        }

        #endregion

        #region Methods

        private void SelectedOptionUpdatedCallback()
        {
            var selectedOptionIndex = _optionSelector.SelectedOptionIndex;
            if (!_volumeOptionsDictionary.TryGetValue(selectedOptionIndex, out var volumeValue))
            {
                return;
            }
            
            AudioVolume.Volume = volumeValue;
        }

        #endregion
    }
}