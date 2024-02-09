using UnityEngine;

namespace Audio.ClipSelectors
{
    public class ClipSelectorSimple : ClipSelector
    {
        #region Editor Fields

        [SerializeField] private AudioClip _clip;

        #endregion
        
        #region Methods

        public override AudioClip Select()
        {
            return _clip;
        }

        #endregion
    }
}