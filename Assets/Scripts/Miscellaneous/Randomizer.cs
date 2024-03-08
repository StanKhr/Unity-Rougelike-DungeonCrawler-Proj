using Unity.Mathematics;

namespace Miscellaneous
{
    public static class Randomizer
    {
        #region Fields

        #endregion

        #region Properties

        private static Random Random { get; set; }

        #endregion
        
        #region Methods

        public static void SetSeed(uint seed)
        {
            Random = new Random(seed);
        }

        public static bool CoinFlip()
        {
            return Random.NextBool();
        }

        public static int RangeInt(int min, int max)
        {
            return Random.NextInt(min, max);
        }

        public static float RangeFloat(float min, float max)
        {
            return Random.NextFloat(min, max);
        }

        public static bool ComparePercent(float compare)
        {
            var percent = Random.NextFloat(0f, 1f);

            return percent <= compare;
        }
        
        #endregion
    }
}