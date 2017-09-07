using System;
using System.Collections;
using UnityEngine;

namespace Wild.GameObjectPool
{
    public class ObjectPoolMB : MonoBehaviour
    {
        public event Action OnUpdated;

        private void Update()
        {
            if (OnUpdated != null)
                OnUpdated();
        }

        public void SetTimeCallback(Action callback, float delay)
        {
            StartCoroutine(DoCallback(callback, delay));
        }

        private IEnumerator DoCallback(Action callback, float delay)
        {
            yield return new WaitForSeconds(delay);
            callback();
        }

    }
}
