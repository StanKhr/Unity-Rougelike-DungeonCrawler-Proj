using UI.Interfaces;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Utility
{
    public class ScanDescription : MonoBehaviour, IScanDescription
    {
        #region Editor Fields

        [SerializeField] private LocalizedString _localizedString;
        [SerializeField] private Color _color = new Color(1f, 1f, 1f, 1f);

        #endregion

        #region Properties

        public string Name => !_localizedString.IsEmpty ? _localizedString.GetLocalizedString() : $"??{name}";
        public Color Color => _color;

        #endregion
    }
}