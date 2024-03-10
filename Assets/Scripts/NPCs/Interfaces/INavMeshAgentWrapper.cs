using UnityEngine;

namespace NPCs.Interfaces
{
    public interface INavMeshAgentWrapper
    {
        #region Properties

        Vector3 Velocity { get; set; }
        Vector3 Destination { get; set; }
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