using System;
using Plugins.StanKhrEssentials.Scripts.UI.Views;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Presenters
{
    public class PersonalityBuilderPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private LocalizedString _genderLocaleMale;
        [SerializeField] private LocalizedString _genderLocaleFemale;

        [Header("Views")]
        [SerializeField] private OptionSelector _genderSelector;
        [SerializeField] private OptionSelector _healthSelector;
        [SerializeField] private OptionSelector _energySelector;
        [SerializeField] private OptionSelector _manaSelector;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            InitializeSelectors();
        }

        #endregion
        
        #region Methods

        private void InitializeSelectors()
        {
            
        }
        
        public bool TryConfirmPersonality()
        {
            // var personality = _personalityCreator.GeneratePersonality();
            // Personality.Active = personality;
            return true;
        }

        #endregion
    }
}