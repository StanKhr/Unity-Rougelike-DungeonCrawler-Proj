using Props.Interfaces;
using UnityEngine;

namespace Props.UseConditions
{
    public class UseConditionComposed : UseCondition, IUseCondition
    {
        #region Editor Fields

        [SerializeField] private UseCondition[] _useConditions;

        #endregion
        
        #region Methods

        public override bool Check(IUsable usable, GameObject user)
        {
            for (int i = 0; i < _useConditions.Length; i++)
            {
                if (!_useConditions[i].Check(usable, user))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}