using System.Collections.Generic;
using UnityEngine;

namespace Wild.Collections
{
    public static class IListExtensions
    {
        public static T GetRandomItem<T>(this IList<T> source)
        {
            if (source.Count == 1)
                return source[0];

            return source[Random.Range(0, source.Count)];
        }

        public static T GetRandomItemFromReadOnlyList<T>(this IReadOnlyList<T> source)
        {
            if (source.Count == 1)
                return source[0];

            return source[Random.Range(0, source.Count)];
        }

        public static T GetByPreferIndex<T>(this IList<T> source, int preferIndex)
        {
            if (source.Count == 1)
                return source[0];

            int trueIndex = CollectionHelper.GetTrueIndex(source.Count, preferIndex);

            return source[trueIndex];
        }

        public static T GetByPreferIndexFromReadOnlyList<T>(this IReadOnlyList<T> source, int preferIndex)
        {
            if (source.Count == 1)
                return source[0];

            int trueIndex = CollectionHelper.GetTrueIndex(source.Count, preferIndex);

            return source[trueIndex];
        }
    }
}
