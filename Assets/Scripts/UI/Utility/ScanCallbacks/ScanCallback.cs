using System;
using UI.Interfaces;
using UnityEngine;

namespace UI.Utility.ScanCallbacks
{
    public abstract class ScanCallback : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private bool _disableWhenTriggered = true;

        #endregion
        
        #region Fields

        private IScanDescription _scanDescription;

        #endregion

        #region Properties

        private IScanDescription ScanDescription => _scanDescription ??= GetComponent<IScanDescription>();

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            ScanDescription.OnObjectScanned += ObjectScannedCallback;
        }

        private void OnDisable()
        {
            ScanDescription.OnObjectScanned -= ObjectScannedCallback;
        }

        #endregion

        #region Methods

        private void ObjectScannedCallback()
        {
            PerformCallbackActions();

            if (!_disableWhenTriggered)
            {
                return;
            }

            enabled = false;
        }
        protected abstract void PerformCallbackActions();

        #endregion
    }
}