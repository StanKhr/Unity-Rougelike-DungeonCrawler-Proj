using Props.Interfaces;
using UnityEngine;

namespace Props.UseConditions
{
    public abstract class UseCondition : MonoBehaviour, IUseCondition
    {
        #region Methods

        public abstract bool Check(IUsable usable, GameObject user);

        #endregion
    }
}