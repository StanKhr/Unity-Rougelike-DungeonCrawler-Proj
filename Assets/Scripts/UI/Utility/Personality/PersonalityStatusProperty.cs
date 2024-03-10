using Miscellaneous;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Utility.Personality
{
    public class PersonalityStatusProperty : MonoBehaviour
    {
        #region Constants

        private const int BaseValue = 100;

        #endregion
        
        #region Events

        public static event DelegateHolder.StatusPropertyEvents OnStatusValueChanged;

        #endregion

        #region Editor Fields

        [SerializeField] private int _minValue = 20;
        [SerializeField] private int _step = 5;
        
        [Header("Views")]
        [SerializeField] private Button _increaseButton;
        [SerializeField] private Button _decreaseButton;
        [SerializeField] private TextMeshProUGUI _valueText;

        #endregion

        #region Fields

        private int _value;

        #endregion

        #region Properties

        public int Value
        {
            get => _value;
            private set
            {
                _value = Mathf.Max(value, _minValue);
                OnStatusValueChanged?.Invoke(this);
                _valueText.text = Value.ToString();
            }
        }

        public int StatusPointsNeeded => (BaseValue - Value) * -1;

        #endregion

        #region Methods

        public void Activate(bool activate)
        {
            if (activate)
            {
                Value = BaseValue;
                _increaseButton.onClick.AddListener(() => Value += _step);
                _decreaseButton.onClick.AddListener(() => Value -= _step);
                return;
            }
            
            _increaseButton.onClick.RemoveAllListeners();
            _decreaseButton.onClick.RemoveAllListeners();
        }

        #endregion
    }
}