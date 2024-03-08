using UnityEngine;

namespace Miscellaneous
{
    public static class Randomizer
    {
        #region Methods

        public static void SetSeed(int seed)
        {
            Random.InitState(seed);
        }

        public static bool CoinFlip()
        {
            return ComparePercent(0.5f);
        }

        public static int RangeInt(int min, int max)
        {
            return Random.Range(min, max);
        }

        public static float RangeFloat(float min, float max)
        {
            return Random.Range(min, max);
        }

        public static bool ComparePercent(float compare)
        {
            var percent = Random.Range(0f, 1f);

            return percent <= compare;
        }
        
        #endregion
    }
}