using Miscellaneous;
using Player.Attacks;
using Player.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UI.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presenters
{
    public class PlayerMeleeAttackPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private PlayerAttack _playerAttack;

        [Header("Views")]
        [SerializeField] private RectTransform _sliderContainer;
        [SerializeField] private Image _sliderFillImage;
        [SerializeField] private RectTransform _critTagRect;

        #endregion

        #region Fields

        private float _defaultWidth;

        #endregion

        #region Properties

        private IPlayerAttack PlayerAttack => _playerAttack;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Init();

            PlayerAttack.OnAttackChargeStarted.AddListener(AttackChargeStartedCallback);
            PlayerAttack.OnAttackReleased.AddListener(AttackReleasedCallback);
            PlayerAttack.OnAttackEnded.AddListener(AttackEndedCallback);
        }

        private void OnDestroy()
        {
            PlayerAttack.OnAttackChargeStarted.RemoveListener(AttackChargeStartedCallback);
            PlayerAttack.OnAttackReleased.RemoveListener(AttackReleasedCallback);
            PlayerAttack.OnAttackEnded.RemoveListener(AttackEndedCallback);
        }

        private void Update()
        {
            if (!PlayerAttack.ChargingAttack)
            {
                return;
            }

            _sliderFillImage.fillAmount = PlayerAttack.ChargePercent;
        }

        #endregion

        #region Methods

        private void Init()
        {
            _defaultWidth = _sliderContainer.sizeDelta.x;
            
            _sliderContainer.gameObject.SetActiveSmart(false);
        }

        private void AttackChargeStartedCallback(Events.MeleeAttackEvent context)
        {
            _sliderFillImage.fillAmount = 0f;

            var sliderSize = _sliderContainer.sizeDelta;
            sliderSize.x = _defaultWidth * context.Weapon.CalculateChargeTimeSeconds();
            _sliderContainer.sizeDelta = sliderSize;

            var critSize = _critTagRect.sizeDelta;
            critSize.x = sliderSize.x * context.Weapon.CritPercentBounds;
            _critTagRect.sizeDelta = critSize;
            
            SetCritTagPosition(context.CritChargePercent);
            
            _sliderContainer.gameObject.SetActiveSmart(true);
        }

        private void AttackEndedCallback()
        {
            _sliderContainer.gameObject.SetActiveSmart(false);
        }

        private void AttackReleasedCallback(Events.WeaponEvent context)
        {
            _sliderContainer.gameObject.SetActiveSmart(false);
        }

        private void SetCritTagPosition(float slidePercent)
        {
            var halvedWidth = _sliderContainer.sizeDelta.x * 0.5f;

            var convertedHorizontalPosition = Mathf.Lerp(-halvedWidth, halvedWidth, slidePercent);

            var critTagPosition = _critTagRect.anchoredPosition;
            critTagPosition.x = convertedHorizontalPosition;
            _critTagRect.anchoredPosition = critTagPosition;
        }

        #endregion
    }
}