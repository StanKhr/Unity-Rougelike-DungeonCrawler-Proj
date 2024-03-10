using System;
using System.Collections.Generic;
using Player.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Utility.Personality
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
        [SerializeField] private Button _genderNextButton;
        [SerializeField] private Button _genderPreviousButton;
        [SerializeField] private TextMeshProUGUI _genderText;

        #endregion

        #region Fields

        private GenderType _selectedGender;
        private List<PersonalityStatusProperty> _statusProperties;
        private Dictionary<GenderType, string> _genderNames;

        #endregion

        #region Properties

        private List<PersonalityStatusProperty> StatusProperties => _statusProperties ??= new List<PersonalityStatusProperty>()
        {
            _healthProperty,
            _staminaProperty,
            _manaProperty
        };

        private Dictionary<GenderType, string> GenderNames
        {
            get
            {
                if (_genderNames != null)
                {
                    return _genderNames;
                }

                _genderNames ??= new Dictionary<GenderType, string>();
                var enumNames = Enum.GetNames(typeof(GenderType));
                for (int i = 0; i < enumNames.Length; i++)
                {
                    _genderNames.Add((GenderType)i, enumNames[i]);
                }

                return _genderNames;
            }
        }

        public bool StatusPointsAllocated => CalculateExpectedSum() == 0;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            PersonalityStatusProperty.OnStatusValueChanged += StatusValueChangedCallback;
            
            _genderNextButton.onClick.AddListener(() => GenderNext(true));
            _genderPreviousButton.onClick.AddListener(() => GenderNext(false));
            
            ActivateProperties(true);
            SelectGender(GenderType.Male);
        }

        private void OnDestroy()
        {
            PersonalityStatusProperty.OnStatusValueChanged -= StatusValueChangedCallback;
            
            _genderNextButton.onClick.RemoveAllListeners();
            _genderPreviousButton.onClick.RemoveAllListeners();
            
            ActivateProperties(false);
        }

        #endregion

        #region Methods

        private void GenderNext(bool moveForward)
        {
            var index = (int) _selectedGender;
            index += moveForward ? 1 : -1;
            if (GenderNames.Values.Count <= index)
            {
                index = 0;
            }
            else if (index < 0)
            {
                index = GenderNames.Values.Count - 1;
            }
            
            SelectGender((GenderType) index);
        }

        private void SelectGender(GenderType genderType)
        {
            _selectedGender = genderType;
            _genderText.text = GenderNames[_selectedGender];
        }

        public Player.Interfaces.Personality GeneratePersonality()
        {
            return new Player.Interfaces.Personality(_selectedGender, (float) _healthProperty.Value,
                (float) _staminaProperty.Value, (float) _manaProperty.Value);
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