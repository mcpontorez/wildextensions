using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.Components
{
    public static class BehaviourExtensions
    {
        public static void SetActiveAndEnabled(this Behaviour target, bool value)
        {
            target.gameObject.SetActive(value);
            target.enabled = value;
        }

        public static void SetActiveAndEnabled(this IEnumerable<Behaviour> target, bool value)
        {
            foreach (var item in target)
            {
                item.SetActiveAndEnabled(value);
            }
        }

        public static void SetEnabled(this IEnumerable<Behaviour> target, bool value)
        {
            foreach (var item in target)
            {
                item.enabled = value;
            }
        }
    }
}
