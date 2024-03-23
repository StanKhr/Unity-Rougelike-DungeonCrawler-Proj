using TMPro;
using UnityEngine;

namespace Plugins.StanKhrEssentials.Scripts.UI.Views
{
    [ExecuteAlways]
    public class TextMeshProResizer : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private bool _resizeWidth;
        [SerializeField] private bool _resizeHeight;
        [SerializeField] private RectTransform _resizeRect;
        [SerializeField] private TextMeshProUGUI _observedText;
        [SerializeField] private Vector2 _extraSize;

        #endregion

        #region Fields

        private Vector2 _prevSize = Vector2.zero;

        #endregion

        #region Unity Callbacks

        private void LateUpdate()
        {
            if (!_observedText)
            {
                return;
            }

            if (!_resizeRect)
            {
                return;
            }

            if (!_resizeWidth && !_resizeHeight)
            {
                return;
            }

            var preferredWidth =
                _resizeWidth ? float.PositiveInfinity : _resizeRect.sizeDelta.x - _observedText.margin.x * 2;
            
            var preferredHeight =
                _resizeHeight ? float.PositiveInfinity : _resizeRect.sizeDelta.y - _observedText.margin.y * 2;
            
            var preferredSize = _observedText.GetPreferredValues(preferredWidth, preferredHeight);
            preferredSize += _extraSize;
            
            var newSize = _prevSize;

            newSize.x = _resizeWidth ? preferredSize.x : _resizeRect.sizeDelta.x;
            newSize.y = _resizeHeight ? preferredSize.y : _resizeRect.sizeDelta.y;

            if (_prevSize == newSize)
            {
                return;
            }

            _prevSize = newSize;

            _resizeRect.sizeDelta = newSize;
        }

        #endregion
    }
}