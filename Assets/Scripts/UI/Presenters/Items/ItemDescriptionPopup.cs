using Player.Inventories.Interfaces;
using TMPro;
using UI.Utility;
using UnityEngine;

namespace UI.Presenters.Items
{
    public class ItemDescriptionPopup : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private TextMeshProUGUI _descriptionText;

        #endregion

        #region Methods

        public void FillDescription(IItem item)
        {
            if (item == null)
            {
                gameObject.SetActiveSmart(false);
                return;
            }
            
            gameObject.SetActiveSmart(true);
            _descriptionText.text = item.CombinedDescription;
        }

        #endregion
    }
}