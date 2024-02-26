using System.Collections.Generic;
using System.Text;
using Player.GameStories;
using Player.Interfaces;
using Player.Miscellaneous;
using TMPro;
using UI.Utility;
using UnityEngine;

namespace UI.Presenters
{
    public class GameStoryPresenter : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private GameStory _gameStory;

        [Header("Views")]
        [SerializeField] private TextMeshProUGUI _storyText;

        #endregion

        #region Properties

        private IGameStory GameStory => _gameStory;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            StoryUpdatedCallback(string.Empty);
            GameStory.OnStoryUpdated += StoryUpdatedCallback;
        }

        private void OnDestroy()
        {
            GameStory.OnStoryUpdated -= StoryUpdatedCallback;
        }

        #endregion

        #region Methods
        
        private void StoryUpdatedCallback(string context)
        {
            _storyText.SetTextSmart(context);
        }

        #endregion
    }
}