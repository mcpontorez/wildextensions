using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.UI.ScreenManagement
{
    public class ScreenSystemManager
    {
        private Transform _container;

        public ScreenSystemManager(Transform container)
        {
            _container = container;
        }

        private Dictionary<Type, Component> _systems = new Dictionary<Type, Component>();

        public bool ContainsSystem<T>() where T : Component
        {
            Type systemType = typeof(T);

            return ContainsSystem(systemType);
        }

        public bool ContainsSystem(Type systemType)
        {
            return _systems.ContainsKey(systemType);
        }

        public T LoadAndAddSystem<T>(string path) where T : Component
        {
            T system = Resources.Load<T>(path);
            system = UnityEngine.Object.Instantiate(system);
            UnityEngine.Object.DontDestroyOnLoad(system.gameObject);
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

            if (!_systems.ContainsKey(systemType))
                return;

            Component system = _systems[systemType];
            UnityEngine.Object.Destroy(_systems[systemType].gameObject);
        }
    }
}
