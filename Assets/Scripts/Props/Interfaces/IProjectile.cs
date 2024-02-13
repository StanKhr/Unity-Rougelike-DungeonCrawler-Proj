using Miscellaneous;
using UnityEngine;

namespace Props.Interfaces
{
    public interface IProjectile
    {
        #region Events

        event DelegateHolder.GameObjectEvents OnVictimFound;

        #endregion
        
        #region Methods

        void Launch();
        void Launch(Vector3 direction);
        void Launch(Vector3 position, Vector3 direction);

        #endregion
    }
}