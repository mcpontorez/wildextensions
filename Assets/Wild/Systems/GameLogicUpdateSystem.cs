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

        private void Update()
        {
            if (OnUpdated != null)
                OnUpdated();
        }

        private void LateUpdate()
        {
            if (OnLateUpdated != null)
                OnLateUpdated();
        }

        private void FixedUpdate()
        {
            if (OnFixedUpdated != null)
                OnFixedUpdated();
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
