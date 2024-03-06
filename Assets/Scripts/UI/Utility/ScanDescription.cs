using System;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Utility
{
    public class ScanDescription : MonoBehaviour, IScanDescription
    {
        #region Events

        public event Action OnObjectScanned;

        #endregion
        
        #region Editor Fields

        [SerializeField] private LocalizedString _localizedString;
        [SerializeField] private Color _color = new Color(1f, 1f, 1f, 1f);

        #endregion

        #region Properties

        public bool LocalizedStringExists => !_localizedString.IsEmpty;
        public string Name => LocalizedStringExists ? _localizedString.GetLocalizedString() : $"??{name}";
        public Color Color => _color;

        #endregion

        #region Methods

        public void ValidateScan()
        {
            OnObjectScanned?.Invoke();
        }

        public void OverrideLocalizedString(LocalizedString localizedString)
        {
            _localizedString = localizedString;
        }

        #endregion
    }
}