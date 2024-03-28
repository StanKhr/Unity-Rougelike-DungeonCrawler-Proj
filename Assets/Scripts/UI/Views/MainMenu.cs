using System.Collections.Generic;
using Player.Inputs;
using Player.Inputs.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using UI.Presenters;
using UI.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class MainMenu : MonoBehaviour
    {
        #region Constants

        private const string ItchLink = "https://lmncf.itch.io/dungeonsofmortreon";

        #endregion
        
        #region Events

        public static IEvent OnDungeonRunStarted { get; } = EventFactory.CreateEvent();
        public static IEvent OnGameExited { get; } = EventFactory.CreateEvent();

        #endregion

        #region Editor Fields

        [Header("Presenters")]
        [SerializeField] private PersonalityBuilderPresenter _personalityBuilderPresenter;

        [Header("Views")]
        [SerializeField] private Button _beginAdventureButton;
        [SerializeField] private Button _personalityConfirmButton;
        [SerializeField] private Button _personalityBackButton;
        [SerializeField] private Button _exitGameButton;
        [SerializeField] private Button _loreButton;
        [SerializeField] private Button _inputsButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _creditsButton;
        [SerializeField] private Button _loreHideButton;        
        [SerializeField] private Button _inputsHideButton;
        [SerializeField] private Button _settingsHideButton;

        [Header("Windows")]
        [SerializeField] private RectTransform _personalityRect;
        [SerializeField] private RectTransform _loreWindowRect;
        [SerializeField] private RectTransform _inputsRect;
        [SerializeField] private RectTransform _settingsRect;

        #endregion

        #region Fields

        private List<Button> _buttons;

        #endregion

        #region Properties

        private ICursorVisibility CursorVisibility { get; } = new CursorVisibility();

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            CursorVisibility.SetVisibility(true);
            
            _buttons = new List<Button>()
            {
                _beginAdventureButton,
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
            
            _exitGameButton.onClick.AddListener(() => OnGameExited?.NotifyListeners());
            _creditsButton.onClick.AddListener(() => Application.OpenURL(ItchLink));
            
            _beginAdventureButton.onClick.AddListener(() => ShowPersonalityCreator(true));
            
            _personalityBackButton.onClick.AddListener(() => ShowPersonalityCreator(false));
            _personalityConfirmButton.onClick.AddListener(TryStartRun);
            
            _loreButton.onClick.AddListener(() => ShowLore(true));
            _loreHideButton.onClick.AddListener(() => ShowLore(false));
            
            _inputsButton.onClick.AddListener(() => ShowInputs(true));
            _inputsHideButton.onClick.AddListener(() => ShowInputs(false));
            
            _settingsButton.onClick.AddListener(() => ShowSettings(true));
            _settingsHideButton.onClick.AddListener(() => ShowSettings(false));
            
            SelectButton(_beginAdventureButton);
        }

        #endregion

        #region Methods

        private void TryStartRun()
        {
            if (!_personalityBuilderPresenter.TryConfirmPersonality())
            {
                return;
            }
            
            OnDungeonRunStarted?.NotifyListeners();
        }

        private void ShowPersonalityCreator(bool show)
        {
            _personalityRect.gameObject.SetActiveSmart(show);
            ShowMainButtons(!show);
            SelectButton(show ? _personalityBackButton : _beginAdventureButton);
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