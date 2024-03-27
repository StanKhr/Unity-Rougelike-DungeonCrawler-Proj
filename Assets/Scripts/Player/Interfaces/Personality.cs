using Player.Enums;

namespace Player.Interfaces
{
    public class Personality
    {
        #region Constants

        private const int BaseStatusValue = 100;
        private const int StatusesCount = 3;

        #endregion

        #region Constructors

        private Personality()
        {
            Gender = GenderType.Female;
            Health = BaseStatusValue;
            Stamina = BaseStatusValue;
            Mana = BaseStatusValue;
        }

        public Personality(GenderType gender, float health, float stamina, float mana)
        {
            Gender = gender;
            Health = health;
            Stamina = stamina;
            Mana = mana;
        }

        #endregion

        #region Fields

        private static Personality _active;
        private static Personality _generic;

        #endregion

        #region Properties

        public static Personality Active
        {
            get => _active ??= new Personality();
            set => _active = value;
        }

        public GenderType Gender { get; private set; }
        public float Health { get; private set; }
        public float Stamina { get; private set; }
        public float Mana { get; private set; }

        #endregion

        #region Static Methods

        public static bool TryCreatePersonality(GenderType gender, int health, int stamina, int mana,
            out Personality personality)
        {
            if (health + stamina + mana != BaseStatusValue * StatusesCount)
            {
                personality = default;
                return false;
            }

            personality = new Personality(gender, health, stamina, mana);
            return true;
        }

        #endregion
    }
}