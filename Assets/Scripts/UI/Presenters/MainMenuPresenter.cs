using System;
using System.Collections.Generic;
using TMPro;
using UI.Utility;
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

        public static event Action OnDungeonRunStarted;
        public static event Action OnGameExited;
        // public static event Action

        #endregion

        #region Editor Fields

        [Header("Views")]
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

        [Header("Windows")]
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
                _startRunButton,
                _exitGameButton,
                _loreButton,
                _inputsButton,
                _creditsButton,
                _settingsButton,
            };
            
            ShowLore(false);
            ShowInputs(false);
            ShowSettings(false);
            
            _startRunButton.onClick.AddListener(() => OnDungeonRunStarted?.Invoke());
            _exitGameButton.onClick.AddListener(() => OnGameExited?.Invoke());
            _creditsButton.onClick.AddListener(() => System.Diagnostics.Process.Start(ItchLink));
            
            _loreButton.onClick.AddListener(() => ShowLore(true));
            _loreHideButton.onClick.AddListener(() => ShowLore(false));
            
            _inputsButton.onClick.AddListener(() => ShowInputs(true));
            _inputsHideButton.onClick.AddListener(() => ShowInputs(false));
            
            _settingsButton.onClick.AddListener(() => ShowSettings(true));
            _settingsHideButton.onClick.AddListener(() => ShowSettings(false));
            
            SelectButton(_startRunButton);
        }

        #endregion

        #region Methods
        
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