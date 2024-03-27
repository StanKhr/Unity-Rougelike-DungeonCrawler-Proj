using System;
using Miscellaneous;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Utility
{
    public class ButtonSelectionEvents : MonoBehaviour, ISelectHandler, IDeselectHandler, ISubmitHandler,
        IPointerClickHandler
    {
        #region Events

        public static IContextEvent<EventContext.GameObjectEvent> OnSelected { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();

        public static IContextEvent<EventContext.GameObjectEvent> OnDeselected { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();

        public static IContextEvent<EventContext.GameObjectEvent> OnSubmitted { get; } =
            EventFactory.CreateContextEvent<EventContext.GameObjectEvent>();

        #endregion

        #region Properties

        private EventContext.GameObjectEvent Context => new() {GameObject = gameObject};

        #endregion

        #region Methods

        public void OnSelect(BaseEventData eventData)
        {
            OnSelected?.NotifyListeners(Context);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            OnDeselected?.NotifyListeners(Context);
        }

        public void OnSubmit(BaseEventData eventData)
        {
            OnSubmitted?.NotifyListeners(Context);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnSubmitted?.NotifyListeners(Context);
        }

        #endregion
    }
}