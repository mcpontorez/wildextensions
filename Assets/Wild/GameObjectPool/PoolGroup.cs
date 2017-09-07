using UnityEngine;using System.Collections;using System.Collections.Generic;

namespace Wild.GameObjectPool
{
    public class PoolGroup<T> : IPoolGroup<T> where T : Component, IMainComponentPoolObject
    {
        public ObjectPool CurrentPool { get; private set; }
        public string Name { get; private set; }
        public T Sample { get; private set; }
        public readonly Transform parent;
        public readonly ObjectPool currentPool;

        private Stack<T> _stack = new Stack<T>();
        public int Count { get { return _stack.Count; } }

        public PoolGroup(T sample, Transform parent, ObjectPool currentPool)
        {
            CurrentPool = currentPool;
            Sample = sample;
            Name = sample.name;
            this.parent = parent;

            CreateObjects();
        }

        private void CreateObjects()
        {
            for (int i = 0; i < Sample.CountToCreatedInPool; i++)
            {
                T objectToPool = Object.Instantiate(Sample);
                objectToPool.name = Name;
                objectToPool.transform.SetParent(parent);
                objectToPool.Initialize(CurrentPool);
                ReturnObject(objectToPool);
            }
        }

        public void ReturnObject(T objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);
            objectToReturn.transform.SetParent(parent);
            _stack.Push(objectToReturn);
        }

        public T GetObject()
        {
            if (_stack.Count < 1)
                CreateObjects();
            T objectFromPool = _stack.Pop();
            objectFromPool.gameObject.SetActive(true);
            objectFromPool.GetFromPool();
            return objectFromPool;
        }

        private float _nextTimeUpdate = 0f;
        /// <summary>
        /// Удаляет лишние объекты
        /// </summary>
        public void Update(float currentTime)
        {
            if (_nextTimeUpdate > currentTime)
                return;

            if (Count > Sample.MaxCountInPool)
                for (int i = 0; i < Sample.CountToDeletedInPool; i++)
                {
                    if (Count <= Sample.MaxCountInPool)
                        break;

                    DestroyObject();
                }

            _nextTimeUpdate = currentTime + Sample.PoolUpdateTimeInterval;
        }

        public void Clear()
        {
            while (Count > 0)
            {
                DestroyObject();
            }
        }

        private void DestroyObject()
        {
            Object.Destroy(_stack.Pop().gameObject);
        }
    }
}