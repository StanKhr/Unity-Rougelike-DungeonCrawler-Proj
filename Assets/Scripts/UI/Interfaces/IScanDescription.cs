using UnityEngine;
using UnityEngine.Localization;

namespace UI.Interfaces
{
    public interface IScanDescription
    {
        #region Properties

        bool LocalizedStringExists { get; }
        string Name { get; }
        Color Color { get; }
        
        #endregion

        #region Methods

        void OverrideLocalizedString(LocalizedString localizedString);

        #endregion
    }
}