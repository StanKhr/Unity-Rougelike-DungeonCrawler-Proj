using System;
using Miscellaneous;
using NPCs.Interfaces;
using UnityEngine;

namespace NPCs.Components
{
    public class PlayerFinder : MonoBehaviour, IPlayerFinder
    {
        #region Constants

        private const string PlayerTag = "Player";

        #endregion
        
        #region Editor Fields

        [SerializeField] private float _scanDelay = 0.5f;
        [SerializeField] private float _scanRadius = 5f;
        [SerializeField] private float _chaseMaxDistance = 7f;
        [SerializeField] private float _stopChaseMinTimeSeconds = 5f;
        [SerializeField] private LayerMask _scanLayers;
        [SerializeField] private LayerMask _obstacleLayers;

        #endregion

        #region Fields

        private float _delay;
        private float _stopChaseTimer;

        private GameObject _playerObject;

        private static readonly Collider[] ScanResults = new Collider[20];

        #endregion

        #region Properties

        private GameObject PlayerObject
        {
            get => _playerObject;
            set => _playerObject = value;
        }
        public bool PlayerFound => PlayerObject;
        public Vector3 PlayerPosition => PlayerObject ? PlayerObject.transform.position : Vector3.zero;

        #endregion

        #region Unity Callbacks

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _scanRadius);
        }
#endif

        #endregion

        #region Methods

        public void Tick(float deltaTime)
        {
            if (PlayerFound)
            {
                var visible = PlayerIsVisible();
                // LogWriter.DevelopmentLog($"Player is visible: {visible}; timer {_delay}");
                if (visible)
                {
                    _delay = _stopChaseMinTimeSeconds;
                    return;
                }
            }
            
            if (_delay > 0f)
            {
                _delay -= deltaTime;
                return;
            }

            if (!PlayerFound)
            {
                _delay = _scanDelay;
                PlayerObject = TryFindPlayer();
                return;
            }

            PlayerObject = null;
        }

        private GameObject TryFindPlayer()
        {
            Array.Clear(ScanResults, 0, ScanResults.Length);

            if (Physics.OverlapSphereNonAlloc(transform.position, _scanRadius, ScanResults, _scanLayers) <= 0)
            {
                return null;
            }

            for (int i = 0; i < ScanResults.Length; i++)
            {
                if (!ScanResults[i])
                {
                    continue;
                }

                if (!ScanResults[i].gameObject.CompareTag(PlayerTag))
                {
                    continue;
                }

                return ScanResults[i].gameObject;
            }
            
            return null;
        }

        private bool PlayerIsVisible()
        {
            var enemyPosition = transform.position;
            var playerPosition = PlayerPosition;
            playerPosition.y = enemyPosition.y;

            if (Vector3.Distance(enemyPosition, playerPosition) > _chaseMaxDistance)
            {
                return false;
            }

            return true;
            // var linecast = Physics.Linecast(enemyPosition, playerPosition, out _, _obstacleLayers);
            // return linecast;
        }

        #endregion
    }
}