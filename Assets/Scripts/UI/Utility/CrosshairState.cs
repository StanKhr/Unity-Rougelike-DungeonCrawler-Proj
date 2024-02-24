using UI.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Utility
{
    public class CrosshairState : MonoBehaviour
    {
        #region Constants

        private static readonly Color ColorBase = new Color(1f, 1f, 1f, 1f);

        #endregion
        
        #region Editor Fields

        [SerializeField] private Image _default;
        [SerializeField] private Image _highlighted;

        #endregion

        #region Fields

        private Image _activeCrosshair;
        private Color _color;

        #endregion

        #region Properties

        private Image ActiveCrosshair
        {
            get => _activeCrosshair;
            set
            {
                if (ActiveCrosshair == value)
                {
                    return;
                }
                
                if (ActiveCrosshair)
                {
                    ActiveCrosshair.gameObject.SetActive(false);
                }

                _activeCrosshair = value;

                if (ActiveCrosshair)
                {
                    ActiveCrosshair.gameObject.SetActive(true);
                    ActiveCrosshair.color = Color;
                }
            }
        }

        private Color Color
        {
            get => _color;
            set
            {
                if (Color == value)
                {
                    return;
                }

                _color = value;

                if (!ActiveCrosshair)
                {
                    return;
                }

                ActiveCrosshair.color = Color;
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

        public void SetColor(Color color)
        {
            Color = color;
        }

        public void ResetColor()
        {
            Color = ColorBase;
        }

        #endregion
    }
}