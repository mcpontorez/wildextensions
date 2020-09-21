using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public static void StopNullableCoroutine(this MonoBehaviour target, IEnumerator coroutine)
        {
            if (coroutine != null)
                target.StopCoroutine(coroutine);
        }

        public static IEnumerator DoStartCoroutine(this MonoBehaviour target, IEnumerator routine)
        {
            target.SetActiveAndEnabled(true);
            yield return target.StartCoroutine(routine);
        }

        public static IEnumerator StartAllCoroutines(this MonoBehaviour monoBehaviour, IEnumerable<IEnumerator> enumerators)
        {
            return enumerators.Select(monoBehaviour.StartCoroutine).ToArray().GetEnumerator();
        }

        public static IEnumerator StartAllCoroutines(this MonoBehaviour monoBehaviour, params IEnumerator[] enumerators) =>
            StartAllCoroutines(monoBehaviour, (IEnumerable<IEnumerator>) enumerators);
    }
}
