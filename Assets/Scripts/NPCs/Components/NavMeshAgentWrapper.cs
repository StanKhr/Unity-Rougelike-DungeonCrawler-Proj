using Cysharp.Threading.Tasks;
using NPCs.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace NPCs.Components
{
    public class NavMeshAgentWrapper : MonoBehaviour, INavMeshAgentWrapper
    {
        #region Editor Fields

        [SerializeField] private NavMeshAgent _navMeshAgent;

        #endregion

        #region Fields

        private NavMeshPath _navMeshPath;

        #endregion

        #region Properties

        private NavMeshAgent Agent => _navMeshAgent;
        public Vector3 Velocity
        {
            get => Agent.velocity;
            set => Agent.velocity = value;
        }
        public Vector3 Destination
        {
            get => Agent.destination;
            set
            {
                if (_navMeshPath == null)
                {
                    _navMeshPath = new NavMeshPath();
                }
                
                if (!Agent.CalculatePath(value, _navMeshPath))
                {
                    return;
                }

                Agent.destination = _navMeshPath.corners[^1];
            }
        }
        public Vector3 NormalizedDesiredVelocity => Agent.desiredVelocity.normalized;
        public bool IsOnNavMesh => Agent.isOnNavMesh;

        #endregion

        #region Methods

        public void EnableAgent(bool state)
        {
            Agent.enabled = state;
            if (state)
            {
                ResetAgentPath();
            }
        }

        public void SetPositionRotationUpdate(bool update)
        {
            Agent.updatePosition = update;
            Agent.updateRotation = update;
        }

        public async void TeleportAgent(Vector3 velocity)
        {
            EnableAgent(false);
            Velocity = velocity;

            await UniTask.Yield();
            EnableAgent(true);
        }

        public bool AgentAvailable()
        {
            if (!Agent)
            {
                return false;
            }

            if (!Agent.enabled)
            {
                return false;
            }

            if (!Agent.isOnNavMesh)
            {
                return false;
            }

            if (Agent.isStopped)
            {
                return false;
            }

            return true;
        }

        private void ResetAgentPath()
        {
            if (!AgentAvailable())
            {
                return;
            }
            
            Agent.ResetPath();
            Velocity = Vector3.zero;
        }
        
        #endregion
    }
}