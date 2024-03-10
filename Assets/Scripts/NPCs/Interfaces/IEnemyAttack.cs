using UnityEngine;

namespace NPCs.Interfaces
{
    public interface IEnemyAttack
    {
        #region Properties

        float AttackChargeTime { get; }
        float AttackReleaseTime { get; }
        float MinAttackDistance { get; }

        #endregion

        #region Methods

        void PerformAttack(Vector3 victimPosition);

        #endregion
    }
}