using System;
using Audio.ClipSelectors;
using Audio.Interfaces;
using Miscellaneous.ObjectPooling;
using NPCs.Components;
using UnityEngine;

namespace Miscellaneous
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
            EnemyAttackMelee.OnAttackAtPointPerformed += AttackPerformedCallback;
        }

        private void OnDestroy()
        {
            EnemyAttackMelee.OnAttackAtPointPerformed -= AttackPerformedCallback;
        }

        #endregion

        #region Methods


        private void AttackPerformedCallback(Vector3 context)
        {
            var particle = (WorldAttackParticle)_particlesPool.Get();
            particle.transform.position = context;
            particle.TriggerAudio(ClipSelector.SelectNext());
        }

        #endregion
    }
}