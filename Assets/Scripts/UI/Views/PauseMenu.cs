using System;
using System.Collections.Generic;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using UI.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class PauseMenu : MonoBehaviour
    {
        #region Events

        public IEvent OnResumed { get; } = EventFactory.CreateEvent();
        public IEvent OnRestarted { get; } = EventFactory.CreateEvent();
        public IEvent OnToMainMenuDirected { get; } = EventFactory.CreateEvent();

        #endregion
        
        #region Editor Fields

        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _toMainMenuButton;
        
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _closeSettingsButton;

        [Header("Windows")]
        [SerializeField] private RectTransform _gameSettingsRect;

        #endregion

        #region Fields

        private List<Button> _buttons;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            SelectButton(_resumeButton);
            
            _resumeButton.onClick.AddListener(OnResumed.NotifyListeners);
            _restartButton.onClick.AddListener(OnRestarted.NotifyListeners);
            _toMainMenuButton.onClick.AddListener(OnToMainMenuDirected.NotifyListeners);
            
            _settingsButton.onClick.AddListener(SettingsButtonClickedCallback);
            _closeSettingsButton.onClick.AddListener(CloseSettingsButtonClickedCallback);
        }

        private void OnDestroy()
        {
            _resumeButton.onClick.RemoveListener(OnResumed.NotifyListeners);
            _restartButton.onClick.RemoveListener(OnRestarted.NotifyListeners);
            _toMainMenuButton.onClick.RemoveListener(OnToMainMenuDirected.NotifyListeners);
            
            _settingsButton.onClick.RemoveListener(SettingsButtonClickedCallback);
            _closeSettingsButton.onClick.RemoveListener(CloseSettingsButtonClickedCallback);
        }

        private void OnDisable()
        {
            ToggleSettings(false);
        }

        #endregion

        #region Methods

        private void SettingsButtonClickedCallback()
        {
            ToggleSettings(true);
        }

        private void CloseSettingsButtonClickedCallback()
        {
            ToggleSettings(false);
        }

        private void ToggleSettings(bool show)
        {
            _gameSettingsRect.gameObject.SetActiveSmart(show);
            ShowButtons(!show);
            SelectButton(show ? _closeSettingsButton : _settingsButton);
        }

        private void ShowButtons(bool show)
        {
            if (_buttons == null)
            {
                _buttons = new List<Button>()
                {
                    _resumeButton,
                    _settingsButton,
                    _restartButton,
                    _toMainMenuButton,
                };
            }

            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].gameObject.SetActiveSmart(show);
            }
        }
        
        private void SelectButton(Button button)
        {
            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }

        #endregion
    }
}