using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presenters
{
    public class DeathPresenter : MonoBehaviour
    {
        #region Events

        public static IEvent OnNewTryTriggered { get; } = EventFactory.CreateEvent();
        public static IEvent OnToMainMenuLeft { get; } = EventFactory.CreateEvent();

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