using System;
using Miscellaneous;
using Player.GameStories.Datas;
using Player.GameStories.Interfaces;
using Statuses.Interfaces;
using Statuses.Main;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace Player.GameStories.StoryEvents
{
    public class StoryEpisodeDamaged : MonoBehaviour, IStoryEpisode
    {
        #region Constants

        private const string DamageValueVariableName = "value";
        private const string DamageSourceVariableName = "source";

        #endregion
        
        #region Editor Fields

        [SerializeField] private Health _playerHealth;

        [SerializeField] private LocalizedString _damagedLocalizedString;
        [SerializeField] private LocalizedString _lethallyDamagedLocalizedString;

        #endregion

        #region Properties

        private IHealth Health => _playerHealth;
        private IDamageable Damageable => _playerHealth;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            Damageable.OnDamaged.AddListener(DamagedCallback);
        }

        private void OnDisable()
        {
            Damageable.OnDamaged.RemoveListener(DamagedCallback);
        }

        #endregion

        #region Methods

        private void DamagedCallback(EventContext.FloatEvent context)
        {
            var selectedLocalizedString = Health.Alive ? _damagedLocalizedString : _lethallyDamagedLocalizedString;
            
            var damageVariable = (StringVariable) selectedLocalizedString[DamageValueVariableName];
            damageVariable.Value = context.Float.ToString("0");
            
            var sourceVariable = (StringVariable) selectedLocalizedString[DamageSourceVariableName];
            sourceVariable.Value = "test";

            var storyEpisodeData = new StoryEpisodeData(selectedLocalizedString.GetLocalizedString());
            (this as IStoryEpisode).TriggerEvent(storyEpisodeData);
        }
        

        #endregion
    }
}