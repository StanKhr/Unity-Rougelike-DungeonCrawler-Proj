using UnityEngine;

namespace Audio.ClipSelectors.Mono
{
    public class ClipSelectorMonoSimple : ClipSelectorMono
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