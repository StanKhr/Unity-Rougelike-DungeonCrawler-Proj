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

        

        #endregion
        
        #region Methods
        
        public void OnSelect(BaseEventData eventData)
        {
            if (!Application.isPlaying)
            {
                return;
            }
            
            _selection.gameObject.SetActive(true);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (!Application.isPlaying)
            {
                return;
            }

            _selection.gameObject.SetActive(false);
        }

        #endregion
    }
}