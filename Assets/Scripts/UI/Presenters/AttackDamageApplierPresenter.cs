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
    public class AttackDamageApplierPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private PlayerMeleeAttack _playerMeleeAttack;

        [Header("Views")]
        [SerializeField] private RectTransform _sliderContainer;
        [SerializeField] private Image _sliderFillImage;

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

        private void AttackChargeStartedCallback(IWeapon context)
        {
            _sliderFillImage.fillAmount = 0f;

            var sliderSize = _sliderContainer.sizeDelta;
            sliderSize.x = _defaultWidth * context.CalculateChargeTimeSeconds();
            _sliderContainer.sizeDelta = sliderSize;
            
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

        #endregion
    }
}