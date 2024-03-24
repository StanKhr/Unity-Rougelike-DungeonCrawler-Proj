using Audio.ClipSelectors;
using Audio.Interfaces;
using Miscellaneous.EventWrapper.Main;
using Miscellaneous.ObjectPooling;
using NPCs.Components;
using UnityEngine;

namespace Miscellaneous.WorldAttackCallbacks
{
    public class WorldAttackParticleSpawner : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private WorldAttackParticle _attackParticle;
        [SerializeField] private ClipSelector _attackClips;

        #endregion

        #region Fields

        private ObjectPoolWrapper _particlesPool;

        #endregion

        #region Properties

        private IClipSelector ClipSelector => _attackClips;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _particlesPool = new ObjectPoolWrapper(_attackParticle);
            EnemyAttackMelee.OnAttackAtPointPerformed.AddListener(AttackPerformedCallback);
        }

        private void OnDestroy()
        {
            EnemyAttackMelee.OnAttackAtPointPerformed.RemoveListener(AttackPerformedCallback);
        }

        #endregion

        #region Methods


        private void AttackPerformedCallback(Events.Vector3Event context)
        {
            var particle = (WorldAttackParticle)_particlesPool.Get();
            particle.transform.position = context.Vector3;
            particle.TriggerAudio(ClipSelector.SelectNext());
        }

        #endregion
    }
}