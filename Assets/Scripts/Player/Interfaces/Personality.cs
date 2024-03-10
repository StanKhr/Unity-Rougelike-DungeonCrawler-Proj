using Player.Enums;

namespace Player.Interfaces
{
    public class Personality
    {
        #region Constants

        private float BaseStatusBalue = 100f;

        #endregion
        
        #region Constructors

        private Personality()
        {
            Gender = GenderType.Female;
            Health = BaseStatusBalue;
            Stamina = BaseStatusBalue;
            Mana = BaseStatusBalue;
        }

        public Personality(GenderType gender, float health, float stamina, float mana)
        {
            
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
    }
}