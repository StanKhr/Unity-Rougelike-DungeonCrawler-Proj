using System;
using System.Collections.Generic;
using Player.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using TMPro;
using UI.Utility;
using UI.Utility.Personality;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Presenters
{
    public class MainMenuPresenter : MonoBehaviour
    {
        #region Constants

        private const string ItchLink = "https://lmncf.itch.io/dungeonsofmortreon";

        #endregion
        
        #region Events

        public static IEvent OnDungeonRunStarted { get; } = new CustomEvent();

        public static IEvent OnGameExited { get; } = new CustomEvent();
        // public static event Action

        #endregion

        #region Editor Fields

        [SerializeField] private PersonalityCreator _personalityCreator;

        [Header("Views")]
        [SerializeField] private Button _createPersonalityButton;
        [SerializeField] private Button _startRunButton;
        [SerializeField] private Button _exitGameButton;
        [SerializeField] private Button _loreButton;
        [SerializeField] private Button _inputsButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _creditsButton;
        [SerializeField] private TextMeshProUGUI _gameTitleText;
        [SerializeField] private TextMeshProUGUI _versionText;
        [SerializeField] private Button _loreHideButton;        
        [SerializeField] private Button _inputsHideButton;
        [SerializeField] private Button _settingsHideButton;
        [SerializeField] private Button _createPersonalityHideButton;

        [Header("Windows")]
        [SerializeField] private RectTransform _personalityRect;
        [SerializeField] private RectTransform _loreWindowRect;
        [SerializeField] private RectTransform _inputsRect;
        [SerializeField] private RectTransform _settingsRect;

        #endregion

        #region Fields

        private List<Button> _buttons;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _gameTitleText.text = Application.productName;
            _versionText.text = $"Build {Application.version}";

            _buttons = new List<Button>()
            {
                _createPersonalityButton,
                _exitGameButton,
                _loreButton,
                _inputsButton,
                _creditsButton,
                _settingsButton,
            };
            
            ShowPersonalityCreator(false);
            ShowLore(false);
            ShowInputs(false);
            ShowSettings(false);
            
            _startRunButton.onClick.AddListener(TryStartRun);
            _exitGameButton.onClick.AddListener(() => OnGameExited?.NotifyListeners());
            _creditsButton.onClick.AddListener(() => Application.OpenURL(ItchLink));
            
            _createPersonalityButton.onClick.AddListener(() => ShowPersonalityCreator(true));
            _createPersonalityHideButton.onClick.AddListener(() => ShowPersonalityCreator(false));
            
            _loreButton.onClick.AddListener(() => ShowLore(true));
            _loreHideButton.onClick.AddListener(() => ShowLore(false));
            
            _inputsButton.onClick.AddListener(() => ShowInputs(true));
            _inputsHideButton.onClick.AddListener(() => ShowInputs(false));
            
            _settingsButton.onClick.AddListener(() => ShowSettings(true));
            _settingsHideButton.onClick.AddListener(() => ShowSettings(false));
            
            SelectButton(_createPersonalityButton);
        }

        #endregion

        #region Methods

        private void TryStartRun()
        {
            if (!_personalityCreator.StatusPointsAllocated)
            {
                return;
            }

            var personality = _personalityCreator.GeneratePersonality();
            Personality.Active = personality;
            
            OnDungeonRunStarted?.NotifyListeners();
        }

        private void ShowPersonalityCreator(bool show)
        {
            _personalityRect.gameObject.SetActiveSmart(show);
            ShowMainButtons(!show);
            SelectButton(show ? _createPersonalityHideButton : _createPersonalityButton);
        }
        
        private void ShowLore(bool show)
        {
            _loreWindowRect.gameObject.SetActiveSmart(show);
            ShowMainButtons(!show);
            SelectButton(show ? _loreHideButton : _loreButton);
        }

        private void ShowInputs(bool show)
        {
            _inputsRect.gameObject.SetActiveSmart(show);
            ShowMainButtons(!show);
            SelectButton(show ? _inputsHideButton : _inputsButton);
        }

        private void ShowSettings(bool show)
        {
            _settingsRect.gameObject.SetActiveSmart(show);
            ShowMainButtons(!show);
            SelectButton(show ? _settingsHideButton : _settingsButton);
        }

        private void ShowMainButtons(bool show)
        {
            foreach (var button in _buttons)
            {
                button.gameObject.SetActiveSmart(show);
            }
        }

        private void SelectButton(Button button)
        {
            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }

        #endregion
    }
}