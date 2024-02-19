using System;
using Miscellaneous;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Utility
{
    public class ButtonCustomSelection : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        #region Editor Fields

        [SerializeField] private RectTransform _selection;

        #endregion
        
        #region Methods
        
        public void OnSelect(BaseEventData eventData)
        {
            _selection.gameObject.SetActive(true);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _selection.gameObject.SetActive(false);
        }

        #endregion
    }
}