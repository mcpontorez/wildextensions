using System;
using System.Collections;
using UnityEngine;
using Wild.Components;
using Wild.Coroutines;

namespace Wild.Systems
{
    public class GameLogicUpdateSystem : MonoBehaviour, IGameLogicUpdateSystem
    {
        public event Action OnUpdated;
        public event Action OnFixedUpdated;
        public event Action OnLateUpdated;

        private void Update() => OnUpdated?.Invoke();

        private void LateUpdate() => OnLateUpdated?.Invoke();

        private void FixedUpdate() => OnFixedUpdated?.Invoke();

        public void Invoke(float delay, Action action) => StartCoroutine(Invoking(delay, action));
        public void InvokeRealtimeDelay(float delay, Action action) => StartCoroutine(InvokingRealtime(delay, action));

        private IEnumerator Invoking(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }
        private IEnumerator InvokingRealtime(float delay, Action action)
        {
            yield return new WaitForSecondsRealtime(delay);
            action?.Invoke();
        }

        public void Repeat(float repeatDelay, Action action, ICancellationToken cancellationToken)
        {
            StartCoroutine(Repeating(repeatDelay, repeatDelay, action, cancellationToken));
        }
        public void Repeat(float firstDelay, float repeatDelay, Action action, ICancellationToken cancellationToken)
        {
            StartCoroutine(Repeating(firstDelay, repeatDelay, action, cancellationToken));
        }

        private IEnumerator Repeating(float firstDelay, float repeatDelay, Action action, ICancellationToken cancellationToken)
        {
            yield return new WaitForSeconds(firstDelay);
            while (!cancellationToken?.Canceled ?? true)
            {
                action?.Invoke();
                yield return new WaitForSeconds(repeatDelay);
            }
        }

        void IGameLogicUpdateSystem.StopNullableCoroutine(Coroutine routine)
        {
            if (this == null)
                return;
            this.StopNullableCoroutine(routine);
        }

        IEnumerator IGameLogicUpdateSystem.StartAllCoroutines(params IEnumerator[] enumerators)
        {
            return this.StartAllCoroutines(enumerators);
        }
    }
}
