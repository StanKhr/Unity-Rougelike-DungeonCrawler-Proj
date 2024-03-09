using UnityEngine;

namespace UI.Utility.ScanCallbacks
{
    public class ScanCallbackObjectEnabler : ScanCallback
    {
        #region Editor Fields

        [SerializeField] private GameObject _objectToEnable;

        #endregion

        #region Methods
        
        protected override void PerformCallbackActions()
        {
            _objectToEnable.SetActiveSmart(true);
        }

        #endregion
    }
}