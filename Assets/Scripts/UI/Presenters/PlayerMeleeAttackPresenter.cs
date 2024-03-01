using System;
using Miscellaneous;
using Player.Attacks;
using Player.Interfaces;
using Player.Inventories.Interfaces;
using UI.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presenters
{
    public class PlayerMeleeAttackPresenter : MonoBehaviour
    {
        #region Constants

        private const float CritRectScale = 0.1f;
        private const float CritTagMinPositionPercent = 0.1f;
        private const float CritTagMaxPositionPercent = 0.9f;

        #endregion
        
        #region Editor Fields

        [SerializeField] private PlayerMeleeAttack _playerMeleeAttack;

        [Header("Views")]
        [SerializeField] private RectTransform _sliderContainer;
        [SerializeField] private Image _sliderFillImage;
        [SerializeField] private RectTransform _critTagRect;

        #endregion

        #region Fields

        private float _defaultWidth;

        #endregion

        #region Properties

        private IPlayerMeleeAttack PlayerMeleeAttack => _playerMeleeAttack;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Init();
            
            PlayerMeleeAttack.OnAttackChargeStarted += AttackChargeStartedCallback;
            PlayerMeleeAttack.OnAttackReleased += AttackReleasedCallback;
            PlayerMeleeAttack.OnAttackEnded += AttackEndedCallback;
        }

        private void OnDestroy()
        {
            PlayerMeleeAttack.OnAttackChargeStarted -= AttackChargeStartedCallback;
            PlayerMeleeAttack.OnAttackReleased -= AttackReleasedCallback;
            PlayerMeleeAttack.OnAttackEnded -= AttackEndedCallback;
        }

        private void Update()
        {
            if (!PlayerMeleeAttack.ChargingAttack)
            {
                return;
            }

            _sliderFillImage.fillAmount = PlayerMeleeAttack.ChargePercent;
        }

        #endregion

        #region Methods

        private void Init()
        {
            _defaultWidth = _sliderContainer.sizeDelta.x;
            
            _sliderContainer.gameObject.SetActiveSmart(false);
        }

        private void AttackChargeStartedCallback(MeleeAttackData context)
        {
            _sliderFillImage.fillAmount = 0f;

            var sliderSize = _sliderContainer.sizeDelta;
            sliderSize.x = _defaultWidth * context.Weapon.CalculateChargeTimeSeconds();
            _sliderContainer.sizeDelta = sliderSize;

            var critSize = _critTagRect.sizeDelta;
            critSize.x = sliderSize.x * CritRectScale;
            _critTagRect.sizeDelta = critSize;
            
            SetCritTagPosition(context.CritChangePercentage);
            
            _sliderContainer.gameObject.SetActiveSmart(true);
        }

        private void AttackEndedCallback()
        {
            _sliderContainer.gameObject.SetActiveSmart(false);
        }

        private void AttackReleasedCallback(IWeapon context)
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