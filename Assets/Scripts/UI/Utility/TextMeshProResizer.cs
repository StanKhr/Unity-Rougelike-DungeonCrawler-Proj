using TMPro;
using UnityEngine;

namespace UI.Utility
{
    [ExecuteAlways]
    public class TextMeshProResizer : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private bool _resizeWidth;
        [SerializeField] private bool _resizeHeight;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private Vector2 _extraSize;

        #endregion

        #region Fields

        private Vector2 _prevSize = Vector2.zero;

        #endregion

        #region Unity Callbacks

        private void LateUpdate()
        {
            if (!_textMeshPro)
            {
                return;
            }

            if (!_rectTransform)
            {
                return;
            }

            if (!_resizeWidth && !_resizeHeight)
            {
                return;
            }

            var preferredWidth =
                _resizeWidth ? float.PositiveInfinity : _rectTransform.sizeDelta.x - _textMeshPro.margin.x * 2;
            var preferredHeight =
                _resizeHeight ? float.PositiveInfinity : _rectTransform.sizeDelta.y - _textMeshPro.margin.y * 2;
            var preferredSize = _textMeshPro.GetPreferredValues(preferredWidth, preferredHeight);
            preferredSize += _extraSize;
            var newSize = _prevSize;

            newSize.x = _resizeWidth ? preferredSize.x : _rectTransform.sizeDelta.x;
            newSize.y = _resizeHeight ? preferredSize.y : _rectTransform.sizeDelta.y;

            if (_prevSize == newSize)
            {
                return;
            }

            _prevSize = newSize;

            _rectTransform.sizeDelta = newSize;
        }

        #endregion
    }
}