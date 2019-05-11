using System;
using System.Collections;
using UnityEngine;

namespace Wild.Components
{
    public static class MonoBehaviourExtensions
    {
        public static Coroutine TryStartCoroutine(this MonoBehaviour target, IEnumerator routine)
        {
            if (target.isActiveAndEnabled)
                return target.StartCoroutine(routine);
            else
                return null;
        }

        public static void StopNullableCoroutine(this MonoBehaviour target, Coroutine coroutine)
        {
            if (coroutine != null)
                target.StopCoroutine(coroutine);
        }
    }
}
