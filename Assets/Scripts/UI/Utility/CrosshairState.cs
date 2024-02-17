using System;
using UI.Enums;
using UnityEngine;

namespace UI.Utility
{
    public class CrosshairState : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private RectTransform _default;
        [SerializeField] private RectTransform _highlighted;

        #endregion

        #region Fields

        private RectTransform _activeCrosshair;

        #endregion

        #region Properties

        private RectTransform ActiveCrosshair
        {
            get => _activeCrosshair;
            set
            {
                if (_activeCrosshair == value)
                {
                    return;
                }
                
                if (_activeCrosshair)
                {
                    _activeCrosshair.gameObject.SetActive(false);
                }

                _activeCrosshair = value;

                if (_activeCrosshair)
                {
                    _activeCrosshair.gameObject.SetActive(true);
                }
            }
        }

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            SelectCrosshair(CrosshairType.Default);
        }

        #endregion

        #region Methods

        public void SelectCrosshair(CrosshairType crosshairType)
        {
            switch (crosshairType)
            {
                case CrosshairType.Default:
                    ActiveCrosshair = _default;
                    break;
                case CrosshairType.Highlighted:
                    ActiveCrosshair = _highlighted;
                    break;
                case CrosshairType.Disabled:
                    ActiveCrosshair = null;
                    break;
                default:
                    ActiveCrosshair = null;
                    break;
            }
        }

        #endregion
    }
}