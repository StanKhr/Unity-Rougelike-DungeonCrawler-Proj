using System;
using System.Collections.Generic;
using Player.Enums;
using TMPro;
using UI.Utility.Personality;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Utility
{
    public class PersonalityCreator : MonoBehaviour
    {
        #region Constants

        // private const string SumMessage = ""
        private static readonly Color ValidColor = Color.green;
        private static readonly Color ErrorColor = Color.red;

        #endregion
        
        #region Editor Fields

        [SerializeField] private PersonalityStatusProperty _healthProperty;
        [SerializeField] private PersonalityStatusProperty _staminaProperty;
        [SerializeField] private PersonalityStatusProperty _manaProperty;

        [Header("Views")]
        [SerializeField] private TextMeshProUGUI _sumText;

        #endregion

        #region Fields

        private List<PersonalityStatusProperty> _statusProperties;

        #endregion

        #region Properties

        private List<PersonalityStatusProperty> StatusProperties => _statusProperties ??= new List<PersonalityStatusProperty>()
        {
            _healthProperty,
            _staminaProperty,
            _manaProperty
        };

        public bool StatusPointsAllocated => CalculateExpectedSum() == 0;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            PersonalityStatusProperty.OnStatusValueChanged += StatusValueChangedCallback;
            ActivateProperties(true);
        }

        private void OnDestroy()
        {
            PersonalityStatusProperty.OnStatusValueChanged -= StatusValueChangedCallback;
            ActivateProperties(false);
        }

        #endregion

        #region Methods

        public Player.Interfaces.Personality GeneratePersonality()
        {
            return new Player.Interfaces.Personality(GenderType.Male, (float) _healthProperty.Value,
                (float) _manaProperty.Value, (float) _staminaProperty.Value);
        }

        private void StatusValueChangedCallback(PersonalityStatusProperty personalityStatusProperty)
        {
            var sum = CalculateExpectedSum();
            _sumText.SetTextSmart(sum > 0 ? $"+{sum.ToString()}" : sum.ToString());
            _sumText.SetColorSmart(sum == 0 ? ValidColor : ErrorColor);
        }

        private int CalculateExpectedSum()
        {
            var sum = 0;
            for (int i = 0; i < StatusProperties.Count; i++)
            {
                sum += StatusProperties[i].StatusPointsNeeded;
            }

            return sum;
        }

        private void ActivateProperties(bool activate)
        {
            for (int i = 0; i < StatusProperties.Count; i++)
            {
                StatusProperties[i].Activate(activate);
            }
        }

        #endregion
    }
}