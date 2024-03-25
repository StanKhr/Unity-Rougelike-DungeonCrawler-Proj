using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Views
{
    public class PauseMenu : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Button _resumeButton;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            SelectButton(_resumeButton);
        }

        #endregion

        #region Methods

        private void SelectButton(Button button)
        {
            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }

        #endregion
    }
}