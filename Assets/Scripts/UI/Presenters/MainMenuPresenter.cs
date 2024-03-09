using System;
using TMPro;
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
        [SerializeField] private Button _creditsButton;
        [SerializeField] private TextMeshProUGUI _gameTitleText;
        [SerializeField] private TextMeshProUGUI _versionText;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _gameTitleText.text = Application.productName;
            _versionText.text = $"Build {Application.version}";
            
            _startRunButton.onClick.AddListener(() => OnDungeonRunStarted?.Invoke());
            _exitGameButton.onClick.AddListener(() => OnGameExited?.Invoke());
            _creditsButton.onClick.AddListener(() => System.Diagnostics.Process.Start(ItchLink));
        }

        #endregion
    }
}