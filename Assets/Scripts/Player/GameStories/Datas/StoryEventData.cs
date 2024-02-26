using System;
using System.Globalization;
using UnityEngine;

namespace Player.GameStories.Datas
{
    public struct StoryEventData
    {
        #region Constructors

        public StoryEventData(string storyLine)
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