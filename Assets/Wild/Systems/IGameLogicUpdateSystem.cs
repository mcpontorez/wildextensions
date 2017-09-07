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
