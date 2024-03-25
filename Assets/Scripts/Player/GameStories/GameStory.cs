using System.Collections.Generic;
using System.Text;
using Miscellaneous;
using Player.GameStories.Datas;
using Player.GameStories.Interfaces;
using Player.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Interfaces;
using Plugins.StanKhrEssentials.EventWrapper.Main;
using UnityEngine;

namespace Player.GameStories
{
    public class GameStory : MonoBehaviour, IGameStory
    {
        #region Constants

        private const int MaxStoryLines = 10;
        private const string NextLineSkip = "\n";

        #endregion
        
        #region Events

        public IContextEvent<EventContext.StringEvent> OnStoryUpdated { get; } =
            EventFactory.CreateContextEvent<EventContext.StringEvent>();

        #endregion

        #region Fields
        
        private readonly List<StoryEpisodeData> _storyLines = new(MaxStoryLines);
        private readonly StringBuilder _stringBuilder = new();

        #endregion
        
        #region Unity Callbacks

        private void Start()
        {
            IStoryEpisode.OnTriggered.AddListener(StoryEpisodeTriggeredCallback);
        }

        private void OnDestroy()
        {
            IStoryEpisode.OnTriggered.RemoveListener(StoryEpisodeTriggeredCallback);
        }

        #endregion

        #region Methods
        
        private void StoryEpisodeTriggeredCallback(EventContext.StoryEpisodeDataEvent context)
        {
            _storyLines.Add(context.StoryEpisodeData);
            while (_storyLines.Count > MaxStoryLines)
            {
                _storyLines.RemoveAt(0);
            }

            if (_storyLines.Count == 0)
            {
                OnStoryUpdated?.NotifyListeners(default);
                
                return;
            }

            _stringBuilder.Clear();

            for (int i = 0; i < _storyLines.Count; i++)
            {
                _stringBuilder.Append("[");
                _stringBuilder.Append(_storyLines[i].EventTime);
                _stringBuilder.Append("] ");
                _stringBuilder.Append(_storyLines[i].StoryLine);
                _stringBuilder.Append(NextLineSkip);
            }
            
            OnStoryUpdated?.NotifyListeners(new EventContext.StringEvent
            {
                String = _stringBuilder.ToString()
            });
        }

        #endregion

    }
}