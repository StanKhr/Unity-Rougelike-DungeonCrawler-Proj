using UnityEngine;

namespace Audio.ClipSelectors.Scriptables
{
    [CreateAssetMenu (menuName = "RPG / Clip Selectors / Simple", fileName = "ClipSelector_Simple_NEW")]
    public class ClipSelectorScriptableSimple : ClipSelectorScriptable
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