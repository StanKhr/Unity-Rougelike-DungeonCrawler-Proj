using UnityEngine;

namespace Audio.ClipSelectors
{
    [CreateAssetMenu (menuName = "RPG / Clip Selectors / Simple", fileName = "ClipSelector_Simple_NEW")]
    public class ClipSelectorSimple : ClipSelector
    {
        #region Editor Fields

        [SerializeField] private AudioClip _clip;

        #endregion
        
        #region Methods

        public override AudioClip SelectNext()
        {
            return _clip;
        }

        #endregion
    }
}