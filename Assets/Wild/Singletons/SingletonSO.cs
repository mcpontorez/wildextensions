using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wild.Singletons
{
    public abstract class SingletonSO<T> : ScriptableObject where T : SingletonSO<T>
    {
        private static T _instance;
        /// <summary>
        /// Ссылка на объект синглетона
        /// </summary>        public static T Instance
        {
            get
            {
                if (_instance)
                    return _instance;
                _instance = CreateInstance<T>();
                _instance = Resources.Load<T>(_instance.DataPath);
                _instance.Initialize();
                return _instance;
            }
        }
        /// <summary>
        /// Путь загрузки ScriptableObject
        /// </summary>
        protected abstract string DataPath { get; }
        /// <summary>
        /// Использовать для инициализации объекта синглотона
        /// </summary>        protected virtual void Initialize() { }
        /// <summary>
        /// Использовать для создания объекта синглотона до первого обращения к Instance
        /// </summary>
        public static T Register()
        {
            return Instance;
        }

    }
}
