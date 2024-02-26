using System.Collections.Generic;
using System.Text;
using Miscellaneous;
using Player.GameStories.Datas;
using Player.GameStories.Interfaces;
using Player.Interfaces;
using UnityEngine;

namespace Player.GameStories
{
    public class GameStory : MonoBehaviour, IGameStory
    {
        #region Constants

        private const int MaxStoryLines = 8;
        private const string NextLineSkip = "\n";

        #endregion
        
        #region Events

        public event DelegateHolder.StringEvents OnStoryUpdated;

        #endregion

        #region Fields
        
        private readonly List<string> _storyLines = new(MaxStoryLines);
        private readonly StringBuilder _stringBuilder = new();

        #endregion
        
        #region Unity Callbacks

        private void Start()
        {
            IStoryEvent.OnTriggered += StoryEventTriggeredCallback;
        }

        private void OnDestroy()
        {
            IStoryEvent.OnTriggered -= StoryEventTriggeredCallback;
        }

        #endregion

        #region Methods
        
        private void StoryEventTriggeredCallback(StoryEventData context)
        {
            _storyLines.Add(context.StoryLine);
            while (_storyLines.Count > MaxStoryLines)
            {
                _storyLines.RemoveAt(_storyLines.Count - 1);
            }

            if (_storyLines.Count == 0)
            {
                OnStoryUpdated?.Invoke(string.Empty);
                return;
            }

            _stringBuilder.Clear();

            for (int i = 0; i < _storyLines.Count; i++)
            {
                _stringBuilder.Append(_storyLines[i]);
                _stringBuilder.Append(NextLineSkip);
            }
            
            OnStoryUpdated?.Invoke(_stringBuilder.ToString());
        }

        #endregion
    }
}