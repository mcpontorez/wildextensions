using UnityEngine;

namespace Wild.Collections
{
    public class CollectionHelper
    {
        public static int GetTrueIndex(int count, int preferIndex) => (int)Mathf.Repeat(preferIndex, count);

        public static int GetPercentage(int index, int indexPercentage, int count) => (int)((100 * index + indexPercentage) / (float)count);

        public static double GetPercentage(int index, double indexPercentage, int count) => ((100 * index + indexPercentage) / count);
    }
}
