using UnityEngine;

namespace Props.Interfaces
{
    public interface IUsable
    {
        #region Properties

        

        #endregion
        
        #region Methods

        bool TryUse(GameObject user);

        #endregion
    }
}