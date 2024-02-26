using UnityEngine;

namespace Props.Interfaces
{
    public interface IUseCondition
    {
        #region Methods

        bool Check(IUsable usable, GameObject user);

        #endregion
    }
}