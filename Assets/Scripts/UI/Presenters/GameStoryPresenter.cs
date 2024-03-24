using Miscellaneous;
using Player.GameStories;
using Player.Interfaces;
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
            StoryUpdatedCallback(default);
            GameStory.OnStoryUpdated.AddListener(StoryUpdatedCallback);
        }

        private void OnDestroy()
        {
            GameStory.OnStoryUpdated.RemoveListener(StoryUpdatedCallback);
        }

        #endregion

        #region Methods
        
        private void StoryUpdatedCallback(EventContext.StringEvent context)
        {
            _storyText.SetTextSmart(context.String);
        }

        #endregion
    }
}