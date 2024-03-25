using System;
using System.Collections.Generic;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.Scripts.EventWrapper.Main;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.StanKhrEssentials.Scripts.UI.Views
{
    public class OptionSelector : MonoBehaviour
    {
        #region Events

        public IEvent OnSelectedOptionUpdated { get; } = EventFactory.CreateEvent();

        #endregion
        
        #region Editor Fields

        [field: SerializeField] public bool UpdateOutputText { get; set; } = true;
        [field: SerializeField] public bool NotifyListeners { get; set; } = true;
        [field: SerializeField] public List<string> Options { get; private set; }
        [field: SerializeField, Header("Views")] public Button ButtonPrevious { get; private set; }
        [field: SerializeField] public Button ButtonNext { get; private set; }
        [field: SerializeField] public TextMeshProUGUI OutputText { get; private set; }

        #endregion

        #region Fields

        private int _selectedOptionIndex = -1;

        #endregion

        #region Properties

        public int SelectedOptionIndex
        {
            get => _selectedOptionIndex;
            private set
            {
                var maxValue = Options.Count - 1;
                int newIndex;
                if (maxValue >= 0)
                {
                    newIndex = (value % (maxValue + 1) + maxValue + 1) % (maxValue + 1);
                }
                else
                {
                    newIndex = 0;
                }
                
                if (newIndex == SelectedOptionIndex)
                {
                    return;
                }

                _selectedOptionIndex = newIndex;

                if (UpdateOutputText)
                {
                    OutputText.SetTextSmart(SelectedOptionValue);
                }

                if (!NotifyListeners)
                {
                    return;
                }
                
                OnSelectedOptionUpdated?.NotifyListeners();
            }
        }

        public string SelectedOptionValue
        {
            get
            {
                if (SelectedOptionIndex >= 0 && SelectedOptionIndex < Options.Count)
                {
                    return Options[SelectedOptionIndex];
                }

                return string.Empty;
            }
        }

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Initialize();
            
            ButtonPrevious.onClick.AddListener(PreviousClickedCallback);
            ButtonNext.onClick.AddListener(NextClickedCallback);
        }

        private void OnDestroy()
        {
            ButtonPrevious.onClick.RemoveListener(PreviousClickedCallback);
            ButtonNext.onClick.RemoveListener(NextClickedCallback);
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            SelectedOptionIndex = 0;
        }

        private void PreviousClickedCallback()
        {
            SelectedOptionIndex--;
        }

        private void NextClickedCallback()
        {
            SelectedOptionIndex++;
        }
        
        #endregion

        #region Public Methods

        public void OverrideOptions(IEnumerable<string> options)
        {
            Options.Clear();
            Options.AddRange(options);
            SelectedOptionIndex = 0;
        }

        #endregion
    }
}