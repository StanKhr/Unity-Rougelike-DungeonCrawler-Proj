using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Utility
{
    public class ScanDescription : MonoBehaviour, IScanDescription
    {
        #region Constants

        private const string NonLocalizedNameText = "!NEEDS TRANSLATION!";

        #endregion
        
        #region Events

        public IEvent OnObjectScanned { get; } = EventFactory.CreateEvent();
        
        #endregion
        
        #region Editor Fields

        [SerializeField] private LocalizedString _localizedString;
        [SerializeField] private Color _color = new Color(1f, 1f, 1f, 1f);

        #endregion

        #region Properties
        public bool LocalizedStringExists => !_localizedString.IsEmpty;
        public string Name => LocalizedStringExists ? _localizedString.GetLocalizedString() : NonLocalizedNameText;
        public Color Color => _color;

        #endregion

        #region Methods

        public void ValidateScan()
        {
            OnObjectScanned?.NotifyListeners();
        }

        public void OverrideLocalizedString(LocalizedString localizedString)
        {
            _localizedString = localizedString;
        }

        #endregion
    }
}