using UI.Interfaces;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Utility
{
    public class ScanDescription : MonoBehaviour, IScanDescription
    {
        #region Editor Fields

        [SerializeField] private LocalizedString _localizedString;

        #endregion

        #region Properties

        public string Name => _localizedString.GetLocalizedString();

        #endregion
    }
}