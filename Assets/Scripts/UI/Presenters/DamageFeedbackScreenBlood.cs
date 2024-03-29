﻿using System.Threading;
using Cysharp.Threading.Tasks;
using Statuses.Feedbacks.Damage;
using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;

namespace UI.Presenters
{
    public class DamageFeedbackScreenBlood : DamageFeedback
    {
        #region Constants

        private const float OneSecondValue = 1f;

        #endregion
        
        #region Editor Fields

        [SerializeField] private Health _playerHealth;
        
        [Header("Views")]
        [SerializeField] private CanvasGroup _canvasGroup;

        [Header("Settings")]
        [SerializeField, Range(0f, 1f)] private float _fullFilledValue = 0.5f;
        [SerializeField] private float _effectDecayDelay = 1f;
        [SerializeField] private float _effectDecaySpeed = 1f;

        #endregion

        #region Fields

        private CancellationTokenSource _cancellationTokenSource;

        #endregion

        #region Properties

        protected override IDamageable Damageable => _playerHealth;
        protected override IHealth Health => _playerHealth;

        #endregion

        #region Unity Callbacks

        protected override void OnEnable()
        {
            base.OnEnable();
            ResetEffect();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _cancellationTokenSource?.Cancel();
        }

        #endregion

        #region Methods

        private void ResetEffect()
        {
            _canvasGroup.alpha = 0f;
        }

        protected override void DamagedCallback(float _)
        {
            TriggerEffect();
        }

        private async void TriggerEffect()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            // show effect
            _canvasGroup.alpha = _fullFilledValue;

            if (_effectDecayDelay > 0f)
            {
                var isCancelled = await UniTask.Delay(Mathf.RoundToInt(_effectDecayDelay * 1000f),
                        cancellationToken: _cancellationTokenSource.Token).SuppressCancellationThrow();
                if (isCancelled)
                {
                    return;
                }
            }

            var time = OneSecondValue;
            while (time > 0f)
            {
                var removeValue = Time.deltaTime * _effectDecaySpeed;
                time -= removeValue;
                _canvasGroup.alpha -= removeValue / _fullFilledValue;

                var isCancelled = await UniTask.Yield(cancellationToken: _cancellationTokenSource.Token)
                    .SuppressCancellationThrow();
                if (isCancelled)
                {
                    return;
                }
            }

            ResetEffect();
        }

        #endregion
    }
}