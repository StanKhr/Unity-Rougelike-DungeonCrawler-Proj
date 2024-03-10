using Player.Enums;

namespace Player.Interfaces
{
    public class Personality
    {
        #region Constructors

        public Personality()
        {
            Gender = GenderType.Female;
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
        
        #endregion
    }
}