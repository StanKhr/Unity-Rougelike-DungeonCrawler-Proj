using Props.Interfaces;
using Statuses.Datas;
using Statuses.Interfaces;
using UnityEngine;

namespace Props
{
    public class GroundTrap : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private PressurePlate _pressurePlate;
        [SerializeField] private Damage _damage;

        #endregion

        #region Properties

        private IInteractable PressurePlate => _pressurePlate;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            PressurePlate.OnInteractionStarted += EnteredCallback;
        }

        private void OnDisable()
        {
            PressurePlate.OnInteractionStarted -= EnteredCallback;
        }

        #endregion

        #region Methods


        private void EnteredCallback(GameObject context)
        {
            if (!context.TryGetComponent<IDamageable>(out var damageable))
            {
                return;
            }
            
            damageable.ApplyDamage(_damage);
        }

        #endregion
    }
}