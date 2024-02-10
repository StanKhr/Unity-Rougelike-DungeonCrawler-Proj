using Statuses.Enums;

namespace Statuses.Datas
{
    public struct Damage
    {
        #region Constructors

        public Damage(float value, DamageType damageType)
        {
            Value = value;
            DamageType = damageType;
        }

        #endregion

        #region Properties

        public float Value { get; set; }
        public DamageType DamageType { get; set; }

        #endregion
    }
}