using System;
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
    }
}
