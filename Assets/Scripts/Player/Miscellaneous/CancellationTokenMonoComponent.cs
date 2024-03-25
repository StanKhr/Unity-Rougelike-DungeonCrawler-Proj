using System.Threading;
using UnityEngine;

namespace Player.Miscellaneous
{
    public abstract class CancellationTokenMonoComponent : MonoBehaviour
    {
        #region Fields

        private CancellationTokenSource _cancellationTokenSource;

        #endregion

        #region Unity Callbacks

        protected virtual void OnDestroy()
        {
            CancelToken();
        }

        #endregion

        #region Methods

        protected CancellationToken RecreateToken()
        {
            CancelToken();
            _cancellationTokenSource = new CancellationTokenSource();
            return _cancellationTokenSource.Token;
        }

        private void CancelToken()
        {
            _cancellationTokenSource?.Cancel();
        }

        #endregion
    }
}