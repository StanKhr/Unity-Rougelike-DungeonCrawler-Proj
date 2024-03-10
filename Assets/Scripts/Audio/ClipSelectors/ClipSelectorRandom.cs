using System.Collections.Generic;
using Miscellaneous;
using UnityEngine;

namespace Audio.ClipSelectors
{
    [CreateAssetMenu (menuName = "RPG / Clip Selectors / Random", fileName = "ClipSelector_Random_NEW")]
    public class ClipSelectorRandom : ClipSelector
    {
        #region Editor Fields

        [SerializeField] private AudioClip[] _clips;

        #endregion

        #region Fields

        private readonly List<AudioClip> _clipsList = new();

        #endregion
        
        #region Methods

        public override AudioClip SelectNext()
        {
            if (_clips.Length <= 0)
            {
                return null;
            }
            
            if (_clipsList.Count <= 0)
            {
                _clipsList.AddRange(_clips);
            }

            var randomIndex = Randomizer.RangeInt(0, _clipsList.Count);
            var clip = _clipsList[randomIndex];
            _clipsList.Remove(clip);

            return clip;
        }

        #endregion
    }
}