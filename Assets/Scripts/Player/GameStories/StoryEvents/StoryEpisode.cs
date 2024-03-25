using Player.GameStories.Datas;
using Player.GameStories.Interfaces;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace Player.GameStories.StoryEvents
{
    public abstract class StoryEpisode : MonoBehaviour, IStoryEpisode
    {
        #region Constants

        private const string VariableName = "value";

        #endregion
        
        #region Methods

        protected void CreateGenericEpisode(string variableName, LocalizedString localizedString)
        {
            var variable = (StringVariable) localizedString[VariableName];
            variable.Value = variableName;

            var storyEpisodeData = new StoryEpisodeData(localizedString.GetLocalizedString());
            (this as IStoryEpisode).TriggerEvent(storyEpisodeData);
        }

        #endregion
    }
}