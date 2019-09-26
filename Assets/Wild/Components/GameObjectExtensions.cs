using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.Components
{
    public static class GameObjectExtensions
    {
        public static void SetActive(this IEnumerable<GameObject> target, bool value)
        {
            foreach (var item in target)
                item.SetActive(value);
        }

        public static void SetActive(this IEnumerable<GameObject> target)
        {
            target.SetActive(true);
        }

        public static void SetDeactive(this IEnumerable<GameObject> target)
        {
            target.SetActive(false);
        }
    }
}
