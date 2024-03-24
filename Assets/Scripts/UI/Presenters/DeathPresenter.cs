using System;
using Plugins.StanKhrEssentials.EventWrapper.Events;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presenters
{
    public class DeathPresenter : MonoBehaviour
    {
        #region Events

        public static IEvent OnNewTryTriggered { get; } = new CustomEvent();
        public static IEvent OnToMainMenuLeft { get; } = new CustomEvent();

        #endregion

        #region Editor Fields
        
        [SerializeField] private Button _newTryButton;
        [SerializeField] private Button _mainMenuButton;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _newTryButton.onClick.AddListener(() => OnNewTryTriggered?.NotifyListeners());
            _mainMenuButton.onClick.AddListener(() => OnToMainMenuLeft?.NotifyListeners());
        }

        #endregion
    }
}