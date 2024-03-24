using Player.Enums;
using Player.Interfaces;
using UnityEngine;

namespace Audio.ClipSelectors
{
    [CreateAssetMenu (menuName = "RPG / Clip Selectors / Gender Based", fileName = "ClipSelector_GenderBased_NEW")]
    public class ClipSelectorGenderBased : ClipSelector
    {
        #region Editor Fields

        [SerializeField] private ClipSelector _male;
        [SerializeField] private ClipSelector _female;

        #endregion
        
        #region Methods
        
        public override AudioClip SelectNext()
        {
            switch (Personality.Active.Gender)
            {
                case GenderType.Male:
                    return _male.SelectNext();
                case GenderType.Female:
                    return _female.SelectNext();
            }
            
            return null;
        }

        #endregion
    }
}