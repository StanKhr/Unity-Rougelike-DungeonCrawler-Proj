using Miscellaneous;

namespace UI.Presenters
{
    public class WeaponDamageValuePresenter : WeaponNamePresenter
    {
        #region Constants

        private const string NoDamageString = "0";

        #endregion
        
        #region Methods

        protected override void WeaponEquippedCallback(EventContext.WeaponEvent context)
        {
            var averageDamage = context.Weapon.DamageValue;
            var maxDamage = averageDamage * context.Weapon.CritDamageMultiplier;

            var damageString = $"{averageDamage.ToString("F1")}-{maxDamage.ToString("F1")}";
            damageString = damageString.Replace(',', '.');
            
            SetValue(damageString);
        }

        protected override void WeaponRemovedCallback(EventContext.WeaponEvent context)
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