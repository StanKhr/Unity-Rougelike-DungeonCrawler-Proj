using UnityEngine;

namespace Player.GameStories.Datas
{
    public struct StoryEventData
    {
        #region Constructors

        public StoryEventData(string storyLine, AudioClip notifyAudio)
        {
            StoryLine = storyLine;
            NotifyAudio = notifyAudio;
        }

        #endregion
        
        #region Properties
        
        public string StoryLine { get; }
        public AudioClip NotifyAudio { get; }
        
        #endregion
    }
}