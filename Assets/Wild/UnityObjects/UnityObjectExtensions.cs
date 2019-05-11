using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Wild.UnityObjects
{
    public static class UnityObjectExtensions
    {
        public static IEnumerable<UnityEngine.Object> CastToUnityObjects<TItem>(this IEnumerable<TItem> target) =>
            target.Cast<UnityEngine.Object>();

        public static IEnumerable<TItem> WhereNotNullsAsUnityObject<TItem>(this IEnumerable<TItem> target) =>
            target.Where(i => i as UnityEngine.Object != null);
    }
}
