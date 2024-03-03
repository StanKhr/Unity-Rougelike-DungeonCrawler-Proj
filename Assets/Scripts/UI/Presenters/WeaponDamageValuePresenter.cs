using Player.Inventories.Interfaces;

namespace UI.Presenters
{
    public class WeaponDamageValuePresenter : WeaponNamePresenter
    {
        #region Constants

        private const string NoDamageString = "0";

        #endregion
        
        #region Methods

        protected override void WeaponEquippedCallback(IWeapon context)
        {
            var averageDamage = context.DamageValue;
            var maxDamage = averageDamage * context.CritDamageMultiplier;

            var damageString = $"{averageDamage.ToString("F1")}-{maxDamage.ToString("F1")}";
            damageString = damageString.Replace(',', '.');
            
            SetValue(damageString);
        }

        protected override void WeaponRemovedCallback(IWeapon context)
        {
            SetValue(NoDamageString);
        }

        protected override void SetValue(string value)
        {
            TextMeshProUGUI.text = value;
        }

        #endregion
    }
}