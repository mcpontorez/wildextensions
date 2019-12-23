using System;
using UnityEngine;namespace Wild.Singletons
{
    public abstract class ForceSingletonMonoBehaviour<T> : MonoBehaviour where T : ForceSingletonMonoBehaviour<T>
    {
        private static T _instance;
        /// <summary>
        /// Ссылка на объект синглетона
        /// </summary>        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                T[] instances = FindObjectsOfType<T>();
                if (instances.Length > 1)
                {
                    Exception exception = new Exception($"{typeof(T).FullName} must not have more than one instance on the stage!");
                    //Debug.LogException(exception);
                    throw exception;
                }
                else if (instances.Length < 1)
                {
                    ArgumentNullException exception = new ArgumentNullException($"{typeof(T).FullName} must not have less than one instance on the stage!");
                    //Debug.LogException(exception);
                    throw exception;
                }
                _instance = instances[0];
                DontDestroyOnLoad(_instance);
                return _instance;
            }
            private set
            {
                if (_instance != null)
                    Destroy(_instance);
                _instance = value;
            }
        }

        /// <summary>
        /// Использовать для создания объекта синглотона до первого обращения к Instance
        /// </summary>
        public static T Register() => Instance;

        protected virtual void Awake()
        {
            Instance = (T) this;
        }
    }}