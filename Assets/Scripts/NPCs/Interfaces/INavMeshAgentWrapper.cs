using UnityEngine;

namespace NPCs.Components.Interfaces
{
    public interface INavMeshAgentWrapper
    {
        #region Properties

        Vector3 Destination { get; }
        Vector3 NormalizedDesiredVelocity { get; }
        bool IsOnNavMesh { get; }

        #endregion
        
        #region Methods
        
        void EnableAgent(bool state);
        bool AgentAvailable();
        void SetPositionRotationUpdate(bool update);
        void TeleportAgent(Vector3 velocity);

        #endregion
    }
}