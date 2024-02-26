using UnityEngine;
using UnityEngine.Localization;

namespace Player.Inventories.ConsumableEffects
{
    [CreateAssetMenu (fileName = "ConsumableEffect_Composed_NEW", menuName = "RPG / Consumable Effects / Composed")]
    public class ConsumableEffectComposed : ConsumableEffect
    {
        #region Editor Fields

        [SerializeField] private bool _independentEffects;
        [SerializeField] private ConsumableEffect[] _effectsArray;
        
        #endregion

        #region Methods

        public override bool TryConsume(GameObject user)
        {
            for (int i = 0; i < _effectsArray.Length; i++)
            {
                if (_independentEffects)
                {
                    _effectsArray[i].TryConsume(user);
                    continue;
                }

                var tryConsumeEffect = _effectsArray[i].TryConsume(user);
                if (!tryConsumeEffect)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}