using UnityEngine;

namespace Audio.ClipSelectors
{
    public abstract class ClipSelector : MonoBehaviour
    {
        #region Methods

        public abstract AudioClip Select();

        #endregion
    }
}