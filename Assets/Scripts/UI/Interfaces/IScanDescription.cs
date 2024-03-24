using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Interfaces
{
    public interface IScanDescription
    {
        #region Events

        IEvent OnObjectScanned { get; }

        #endregion
        
        #region Properties

        bool LocalizedStringExists { get; }
        string Name { get; }
        Color Color { get; }
        
        #endregion

        #region Methods

        void ValidateScan();
        void OverrideLocalizedString(LocalizedString localizedString);

        #endregion
    }
}