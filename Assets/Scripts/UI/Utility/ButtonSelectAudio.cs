using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Utility
{
    public class ButtonSelectAudio : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler, IPointerClickHandler
    {
        #region Events

        public static event Action OnSelected;
        public static event Action OnDeselected;
        public static event Action OnSubmitted;

        #endregion
        
        #region Methods

        public void OnSelect(BaseEventData eventData)
        {
            OnSelected?.Invoke();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            OnDeselected?.Invoke();
        }

        public void OnSubmit(BaseEventData eventData)
        {
            OnSubmitted?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnSubmitted?.Invoke();
        }

        #endregion
    }
}