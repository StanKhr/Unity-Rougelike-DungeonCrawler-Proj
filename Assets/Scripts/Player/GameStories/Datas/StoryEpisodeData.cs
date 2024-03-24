using System;

namespace Player.GameStories.Datas
{
    public struct StoryEpisodeData
    {
        #region Constructors

        public StoryEpisodeData(string storyLine)
        {
            StoryLine = storyLine;
            // EventTime = DateTime.Now.ToString("HH:mm:ss");
            EventTime = DateTime.Now.ToString("HH:mm");
        }

        #endregion
        
        #region Properties
        
        public string StoryLine { get; }
        public string EventTime { get; }
        
        #endregion
    }
}