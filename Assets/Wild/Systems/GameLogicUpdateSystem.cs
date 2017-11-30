using System;
using System.Collections;
using UnityEngine;

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

        public void InvokeWithDelay(float delay, Action action) => StartCoroutine(Invoking(delay, false, action));
        public void InvokeWithDelayRealtime(float delay, Action action) => StartCoroutine(Invoking(delay, true, action));

        private IEnumerator Invoking(float delay, bool isRealtime, Action action)
        {
            if (isRealtime)
                yield return new WaitForSecondsRealtime(delay);
            else
                yield return new WaitForSeconds(delay);

            action?.Invoke();
        }

        void IGameLogicUpdateSystem.StopCoroutine(IEnumerator routine)
        {
            if (this == null)
                return;
            StopCoroutine(routine);
        }

        void IGameLogicUpdateSystem.StopCoroutine(Coroutine routine)
        {
            if (this == null)
                return;
            StopCoroutine(routine);
        }
    }
}
