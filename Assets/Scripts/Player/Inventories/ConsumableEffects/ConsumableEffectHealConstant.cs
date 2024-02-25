using Statuses.Interfaces;
using UnityEngine;

namespace Player.Inventories.ConsumableEffects
{
    [CreateAssetMenu (fileName = "ConsumableEffect_HealConstant_NEW", menuName = "RPG / Consumable Effects / Heal Constant")]
    public class ConsumableEffectHealConstant : ConsumableEffect
    {
        #region Editor Fields

        [SerializeField, Min(0f)] private float _healValue;

        #endregion
        
        #region Methods

        public override bool TryConsume(GameObject user)
        {
            if (!user.TryGetComponent<IHealth>(out var health))
            {
                return false;
            }

            if (!health.Alive)
            {
                return false;
            }

            return health.TryHeal(_healValue);
        }

        #endregion
    }
}