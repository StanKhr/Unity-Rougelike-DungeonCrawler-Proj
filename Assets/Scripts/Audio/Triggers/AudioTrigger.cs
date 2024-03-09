using UnityEngine;

namespace Audio.Triggers
{
    public abstract class AudioTrigger : MonoBehaviour
    { 
        #region Editor Fields

        [field: SerializeField] protected AudioSource AudioSource { get; private set; }

        #endregion
    }
}