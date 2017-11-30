using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.Systems.Management
{
    public class SystemManager
    {
        private readonly Transform _container;

        public SystemManager(Transform container)
        {
            _container = container;
        }

        public SystemManager(string name = null)
        {
            GameObject container = new GameObject(name ?? nameof(SystemManager));
            UnityEngine.Object.DontDestroyOnLoad(container);
            _container = container.transform;
        }

        private Dictionary<Type, Component> _systems = new Dictionary<Type, Component>();

        public bool ContainsSystem<T>() where T : Component
            => ContainsSystem(typeof(T));

        public bool ContainsSystem(Type systemType) => _systems.ContainsKey(systemType);

        public T LoadAndAddSystem<T>(string path) where T : Component
        {
            T system = Resources.Load<T>(path);
            return CreateSystem(system);
        }

        public T CreateSystem<T>(T sampleSystem) where T : Component
        {
            T system = UnityEngine.Object.Instantiate(sampleSystem);
            AddSystem(system);
            return system;
        }

        public T GetSystem<T>() where T : Component
        {
            Type systemType = typeof(T);

            if (ContainsSystem(systemType))
                   return (T)_systems[systemType];

            GameObject gameObject = new GameObject(systemType.ToString());
            T system = gameObject.AddComponent<T>();
            AddSystem(system);
            return system;
        }

        public void AddSystem<T>(T system) where T : Component
        {
            Type systemType = typeof(T);

            if (ContainsSystem(systemType))
                throw new Exception("This system already exists");

            _systems.Add(systemType, system);

            system.transform.SetParent(_container);
        }

        public void DestroySystem<T>()
        {
            Type systemType = typeof(T);

            if (!ContainsSystem(systemType))
                return;

            Component system = _systems[systemType];
            UnityEngine.Object.Destroy(_systems[systemType].gameObject);
        }

       public void Clear()
       {
            foreach (var system in _systems)
            {
                UnityEngine.Object.Destroy(system.Value.gameObject);
            }
            _systems.Clear();
       }
    }
}
