using Statuses.Interfaces;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace Player.Inventories.ConsumableEffects
{
    [CreateAssetMenu (fileName = "ConsumableEffect_HealConstant_NEW", menuName = "RPG / Consumable Effects / Heal Constant")]
    public class ConsumableEffectHealConstant : ConsumableEffect
    {
        #region Constants

        private const string VariableName = "value";

        #endregion
        
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

        public override string GetDescription()
        {
            var localizedString = GetLocalizedString();
            var variable = (StringVariable) localizedString[VariableName];
            variable.Value = _healValue.ToString("F");

            return localizedString.GetLocalizedString();
        }

        #endregion
    }
}