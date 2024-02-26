using Miscellaneous;
using Props.Interfaces;
using UnityEngine;

namespace Props.Common
{
    public abstract class Usable : MonoBehaviour, IUsable
    {
        #region Methods

        public bool TryUse(GameObject user)
        {
            if (!TryGetComponent<IUseCondition>(out var useCondition))
            {
                return PerformUseLogic(user);
            }

            if (!useCondition.Check(this, user))
            {
                return false;
            }

            return PerformUseLogic(user);
        }

        protected abstract bool PerformUseLogic(GameObject user);

        #endregion
    }
}