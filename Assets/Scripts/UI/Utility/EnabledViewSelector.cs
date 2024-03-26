using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Utility
{
    public class EnabledViewSelector : MonoBehaviour
    {
        #region Unity Callbacks

        private void OnEnable()
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        #endregion
    }
}