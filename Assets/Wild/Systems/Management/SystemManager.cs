﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.Systems.Management
{
    public class SystemManager
    {
        private Transform _container;

        public SystemManager(Transform container)
        {
            UnityEngine.Object.DontDestroyOnLoad(container);
            _container = container;
        }

        public SystemManager(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = "SystemManager";

            GameObject container = new GameObject(name);
            UnityEngine.Object.DontDestroyOnLoad(container);
            _container = container.transform;
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