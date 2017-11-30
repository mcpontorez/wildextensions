using System;
using System.Collections;
using UnityEngine;

namespace Wild.Systems
{
    public interface IGameLogicUpdateSystem
    {
        event Action OnUpdated;
        event Action OnFixedUpdated;
        event Action OnLateUpdated;

        void InvokeWithDelay(float delay, Action action);
        void InvokeWithDelayRealtime(float delay, Action action);
        /// <summary>
        /// Проверяет себя != null и останавливает корутину
        /// </summary>
        /// <param name="routine"></param>
        void StopCoroutine(IEnumerator routine);
        /// <summary>
        /// Проверяет себя != null и останавливает корутину
        /// </summary>
        /// <param name="routine"></param>
        void StopCoroutine(Coroutine routine);
        Coroutine StartCoroutine(IEnumerator enumerator);
    }
}
