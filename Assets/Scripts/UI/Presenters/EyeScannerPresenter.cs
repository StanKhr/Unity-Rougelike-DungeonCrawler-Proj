using System;
using Player.Miscellaneous;
using TMPro;
using UI.Utility;
using UnityEngine;

namespace UI.Presenters
{
    public class EyeScannerPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private EyeScanner _eyeScanner;

        [Header("Views")]
        [SerializeField] private RectTransform _context;
        [SerializeField] private TextMeshProUGUI _text;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            FillPopup(null);
            _eyeScanner.OnTargetFound += TargetFoundCallback;
            _eyeScanner.OnTargetLost += TargetLostCallback;
        }

        private void OnDisable()
        {
            _eyeScanner.OnTargetFound -= TargetFoundCallback;
            _eyeScanner.OnTargetLost -= TargetLostCallback;
        }

        #endregion

        #region Methods
        
        private void TargetFoundCallback(GameObject context)
        {
            FillPopup(context);
        }

        private void TargetLostCallback()
        {
            FillPopup(null);
        }

        private void FillPopup(GameObject scannedObject)
        {
            _text.SetTextSmart(scannedObject ? scannedObject.name : string.Empty);
            _context.gameObject.SetActive(scannedObject);
        }

        #endregion
    }
}