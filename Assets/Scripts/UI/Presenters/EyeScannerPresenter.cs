using System;
using Miscellaneous;
using Player.Miscellaneous;
using TMPro;
using UI.Enums;
using UI.Interfaces;
using UI.Utility;
using UnityEngine;

namespace UI.Presenters
{
    public class EyeScannerPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private EyeScanner _eyeScanner;

        [Header("Views")]
        [SerializeField] private RectTransform _popupContainer;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private CrosshairState _crosshairState;

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
            context.TryGetComponent<IScanDescription>(out var scanDescription);
            FillPopup(scanDescription);
        }

        private void TargetLostCallback()
        {
            FillPopup(null);
        }

        private void FillPopup(IScanDescription scanDescription)
        {
            var descriptionExists = scanDescription != null;
            
            _text.SetTextSmart(descriptionExists ? scanDescription.Name : string.Empty);
            _popupContainer.gameObject.SetActive(descriptionExists);
            
            _crosshairState.SelectCrosshair(descriptionExists ? CrosshairType.Highlighted : CrosshairType.Default);
            if (descriptionExists)
            {
                _crosshairState.SetColor(scanDescription.Color);
                return;
            }
            
            _crosshairState.ResetColor();
        }

        #endregion
    }
}