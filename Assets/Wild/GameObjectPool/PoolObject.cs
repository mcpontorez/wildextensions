using UnityEngine;using System.Collections.Generic;
using System.Linq;
using System;

namespace Wild.GameObjectPool
{
    public class PoolObject : MonoBehaviour, IMainComponentPoolObject
    {
        public ObjectPool CurrentPool { get; private set; }

        private bool _inPool = false;
        public bool InPool
        {
            get { return _inPool; }
            private set
            {
                _inPool = value;

                if (CurrentPool == null)
                    return;

                if (_inPool)
                    CurrentPool.OnReturnAll -= ReturnToPool;
                else
                    CurrentPool.OnReturnAll += ReturnToPool;
            }
        }
        /// <summary>
        /// Желаемое максимальное количество объектов в пуле
        /// </summary>
        [SerializeField]
        private int _maxCountInPool = 10;
        public int MaxCountInPool { get { return _maxCountInPool; } set { _maxCountInPool = value; } }
        /// <summary>
        /// Количество объектов, создаваемое при пустом пуле
        /// </summary>
        [SerializeField]
        private int _countToCreatedInPool = 2;
        public int CountToCreatedInPool { get { return _countToCreatedInPool; } set { _countToCreatedInPool = value; } }
        /// <summary>
        /// Количество объектов, удаляемое за одно обновление пула
        /// </summary>
        [SerializeField]
        private int _countToDeletedInPool = 3;
        public int CountToDeletedInPool { get { return _countToDeletedInPool; }set { _countToDeletedInPool = value; } }

        [SerializeField]
        private float _poolUpdateTimeInterval = 10f;
        public float PoolUpdateTimeInterval { get { return _poolUpdateTimeInterval; } set { _poolUpdateTimeInterval = value; } }

        /// <summary>
        /// Компоненты, висящие на ГО, и управляемые пулом
        /// </summary>
        private List<IOtherComponentPoolObject> _managesPool;

        /// <summary>
        /// Использовать для получения ссылок на другие компоненты игрового объекта
        /// </summary>
        public virtual void Initialize(ObjectPool currentPool)
        {
            CurrentPool = currentPool;

            InPool = true;

            _managesPool = GetComponents<IOtherComponentPoolObject>().ToList();

            foreach (IOtherComponentPoolObject item in _managesPool)
            {
                item.Initialize(this);
            }
        }

        /// <summary>
        /// Вызывать при доставании из пула
        /// </summary>
        public virtual void GetFromPool()
        {
            InPool = false;

            foreach (IOtherComponentPoolObject item in _managesPool)
            {
                item.GetFromPool();
            }
        }
        /// <summary>
        /// Вызывается при возвращении в пул
        /// </summary>
        public event System.Action OnToPoolReturned;
        /// <summary>
        /// Использовать для возвращения в пул
        /// </summary>
        public void ReturnToPool(float delay)
        {
            if (InPool)
                return;
            CurrentPool.ObjectPoolMB.SetTimeCallback(ReturnToPool, delay);
        }
        /// <summary>
        /// Использовать для возвращения в пул
        /// </summary>
        public void ReturnToPool()
        {
            if (InPool)
                return;

            if (CurrentPool != null)
            {
                PrepareReturnToPool();
                InPool = true;
                CurrentPool.ReturnObject(this);
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            if (OnToPoolReturned != null)
                OnToPoolReturned();
            OnToPoolReturned = null;            
        }

        /// <summary>
        /// Использовать для дополнительных изменений перед возвращением в пул. Например, откат анимаций
        /// </summary>
        public virtual void PrepareReturnToPool()
        {
            foreach (IOtherComponentPoolObject item in _managesPool)
            {
                item.PrepareReturnToPool();
            }
        }

        public void OnDestroy()
        {
            InPool = true;
        }        
    }
}