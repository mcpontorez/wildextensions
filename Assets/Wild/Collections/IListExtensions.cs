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
    }
}
