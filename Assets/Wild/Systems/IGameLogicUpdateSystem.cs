using System;
using System.Collections;
using UnityEngine;
using Wild.Coroutines;

namespace Wild.Systems
{
    public interface IGameLogicUpdateSystem
    {
        event Action Updated;
        event Action FixedUpdated;
        event Action LateUpdated;

        void Invoke(float delay, Action action);
        void InvokeRealtimeDelay(float delay, Action action);
        void Repeat(float repeatDelay, Action action, ICancellationToken cancellationToken);
        void Repeat(float firstDelay, float repeatDelay, Action action, ICancellationToken cancellationToken);
        /// <summary>
        /// Проверяет себя != null и останавливает корутину
        /// </summary>
        /// <param name="routine"></param>
        void StopCoroutine(IEnumerator routine);
        /// <summary>
        /// Проверяет себя и корутину != null и останавливает корутину
        /// </summary>
        /// <param name="routine"></param>
        void StopNullableCoroutine(Coroutine routine);
        Coroutine StartCoroutine(IEnumerator enumerator);
        IEnumerator StartAllCoroutines(params IEnumerator[] enumerators);
    }
}
