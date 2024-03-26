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
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _toMainMenuButton;

        [Header("Windows")]
        [SerializeField] private RectTransform _gameSettingsRect;

        #endregion

        #region Fields

        private List<Button> _buttons;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            SelectButton(_resumeButton);
            
            _resumeButton.onClick.AddListener(OnResumed.NotifyListeners);
            _restartButton.onClick.AddListener(OnRestarted.NotifyListeners);
            _toMainMenuButton.onClick.AddListener(OnToMainMenuDirected.NotifyListeners);
            
            _settingsButton.onClick.AddListener(ToggleSettings);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(OnResumed.NotifyListeners);
            _restartButton.onClick.RemoveListener(OnRestarted.NotifyListeners);
            _toMainMenuButton.onClick.RemoveListener(OnToMainMenuDirected.NotifyListeners);
        }

        #endregion

        #region Methods
        
        private void SelectButton(Button button)
        {
            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }

        private void ToggleSettings()
        {
            var show = !_gameSettingsRect.gameObject.activeSelf;
            _gameSettingsRect.gameObject.SetActiveSmart(show);
            ShowButtons(!show);
            // SelectButton(_settingsButton);
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

        #endregion
    }
}