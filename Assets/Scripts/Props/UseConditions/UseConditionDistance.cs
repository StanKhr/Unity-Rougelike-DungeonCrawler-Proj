using Props.Interfaces;
using UnityEngine;

namespace Props.UseConditions
{
    public class UseConditionDistance : MonoBehaviour, IUseCondition
    {
        #region Editor Fields
        
        [SerializeField] private float _useDistance = 2f;

        #endregion
        
        #region Methods

        public bool Check(IUsable usable, GameObject user)
        {
            var distance = Vector3.Distance(user.transform.position, transform.position);
            return distance <= _useDistance;
        }

        #endregion
    }
}