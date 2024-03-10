using UnityEngine;

namespace NPCs.Interfaces
{
    public interface IPlayerFinder
    {
        #region Properties

        bool PlayerFound { get; }
        Vector3 PlayerPosition { get; }

        #endregion

        #region Methods

        void Tick(float deltaTime);

        #endregion
    }
}