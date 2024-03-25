using UnityEngine;

namespace Miscellaneous
{
    public class WebGLObjectDisabler : MonoBehaviour
    {
        #region Unity Callbacks

        private void Start()
        {
            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                return;
            }
            
            gameObject.SetActive(false);
        }

        #endregion
    }
}