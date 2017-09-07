using System;
using UnityEngine;

namespace Wild.GameObjectPool
{
    public interface IPoolGroup<T> where T : Component, IMainComponentPoolObject
    {
        ObjectPool CurrentPool { get; }

        string Name { get; }
        T Sample { get; }
        int Count { get; }

        void ReturnObject(T objectToReturn);

        T GetObject();

        void Update(float currentTime);

        void Clear();
    }
}
