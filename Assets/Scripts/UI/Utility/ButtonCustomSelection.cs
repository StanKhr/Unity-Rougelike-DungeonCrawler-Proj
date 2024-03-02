using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Utility
{
    public class ButtonCustomSelection : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        #region Editor Fields

        [SerializeField] private RectTransform _selection;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            if (EventSystem.current.currentSelectedGameObject != gameObject)
            {
                return;
            }
            
            ActivateSelection(true);
        }

        #endregion
        
        #region Methods
        
        public void OnSelect(BaseEventData eventData)
        {
            ActivateSelection(true);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            ActivateSelection(false);
        }

        private void ActivateSelection(bool activate)
        {
            if (!Application.isPlaying)
            {
                return;
            }
            
            _selection.gameObject.SetActiveSmart(activate);
        }

        #endregion
    }
}