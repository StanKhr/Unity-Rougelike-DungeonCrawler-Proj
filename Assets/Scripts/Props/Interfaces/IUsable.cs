using UnityEngine;

namespace Props.Interfaces
{
    public interface IUsable
    {
        #region Methods
        
        bool TryUse(GameObject user);

        #endregion
    }
}