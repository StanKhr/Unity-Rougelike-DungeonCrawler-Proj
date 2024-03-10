using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presenters
{
    public class DeathPresenter : MonoBehaviour
    {
        #region Events

        public static event Action OnNewTryTriggered;
        public static event Action OnToMainMenuLeft;

        #endregion

        #region Editor Fields
        
        [SerializeField] private Button _newTryButton;
        [SerializeField] private Button _mainMenuButton;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _newTryButton.onClick.AddListener(() => OnNewTryTriggered?.Invoke());
            _mainMenuButton.onClick.AddListener(() => OnToMainMenuLeft?.Invoke());
        }

        #endregion
    }
}