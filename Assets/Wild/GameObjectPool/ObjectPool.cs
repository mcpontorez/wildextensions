using UnityEngine;using System.Collections;
using System.Collections.Generic;
using Wild.InterfacesMB;
using Wild.Singletons;

namespace Wild.GameObjectPool
{
    public class ObjectPool
    {
        private readonly ObjectPoolMB _objectPoolMB;
        public ObjectPoolMB ObjectPoolMB { get { return _objectPoolMB; } }

        public ObjectPool(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = "ObjectPool";

            GameObject gameObject = new GameObject(name);
            Object.DontDestroyOnLoad(gameObject);
            _objectPoolMB = gameObject.AddComponent<ObjectPoolMB>();
            _objectPoolMB.OnUpdated += Update;
        }

        private Dictionary<string, IPoolGroup<PoolObject>> _groups = new Dictionary<string, IPoolGroup<PoolObject>>();

        public T GetObject<T>(T sample) where T : PoolObject
        {
            if (!_groups.ContainsKey(sample.name))
                _groups.Add(sample.name, new PoolGroup<PoolObject>(sample, _objectPoolMB.transform, this));

            return (T)_groups[sample.name].GetObject();
        }

        public T GetObject<T>(string samplePathOrName) where T : PoolObject
        {
            if (string.IsNullOrEmpty(samplePathOrName))
                return null;

            string sampleName = samplePathOrName;
            if (samplePathOrName.LastIndexOf("/") >= 0)
                sampleName = samplePathOrName.Remove(0, samplePathOrName.LastIndexOf("/") + 1);
            if (!_groups.ContainsKey(sampleName))
            {
                T sample = Resources.Load<T>(samplePathOrName);
                _groups.Add(sample.name, new PoolGroup<PoolObject>(sample, _objectPoolMB.transform, this));
            }

            return (T)_groups[sampleName].GetObject();
        }

        public void ReturnObject<T>(T objectToReturn) where T : PoolObject
        {
            if (!_groups.ContainsKey(objectToReturn.name))
                Object.Destroy(objectToReturn.gameObject);
            else
                _groups[objectToReturn.name].ReturnObject(objectToReturn);

        }

        /// <summary>
        /// возвращает все объекты в пулл, вызывать при перезагрузке сцены
        /// </summary>
        public void ReturnAll()
        {
            if (OnReturnAll != null)
                OnReturnAll();

            OnReturnAll = null;
        }

        /// <summary>
        /// Подписываться каждому объекту предназначенному для возвращения в пулл при вытаскивании из пула
        /// </summary>
        public event System.Action OnReturnAll;

        [SerializeField]
        private float _timeIntervalUpdatePool = 1f;
        public float TimeIntervalUpdatePool
        {
            get { return _timeIntervalUpdatePool; }
            set { _timeIntervalUpdatePool = value; _nextPoolUpdate = Time.unscaledTime + _timeIntervalUpdatePool; }
        }
        private float _nextPoolUpdate = 0.1f;

        private void Update()
        {
            if (_nextPoolUpdate > Time.unscaledTime)
                return;

            foreach (var item in _groups)
            {
                item.Value.Update(Time.unscaledTime);
            }
            _nextPoolUpdate = Time.unscaledTime + _timeIntervalUpdatePool;
        }
    }
}