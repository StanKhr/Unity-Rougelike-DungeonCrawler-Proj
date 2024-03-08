using System.Collections.Generic;

namespace Miscellaneous
{
    public static class CodeExtensions
    {
        #region Methods

        public static T GetRandomElementAndRemove<T>(this List<T> list)
        {
            if (list.Count <= 0)
            {
                return default;
            }

            var index = Randomizer.RangeInt(0, list.Count);
            var element = list[index];
            list.RemoveAt(index);

            return element;
        }

        #endregion
    }
}