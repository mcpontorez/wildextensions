﻿using System;
using UnityEngine;
{
    public abstract class SingletonFinderMB<T> : MonoBehaviour where T : SingletonFinderMB<T>
    {
        private static T _instance;
        /// <summary>
        /// Ссылка на объект синглетона
        /// </summary>
        {
            get
            {
                if (_instance != null)
                    return _instance;

                T[] instances = FindObjectsOfType<T>();
                if (instances.Length > 1)
                {
                    Exception exception = new Exception($"{typeof(T).FullName} must not have more than one copy on the stage!");
                    Debug.LogException(exception);
                }
                else if (instances.Length < 1)
                {
                    ArgumentNullException exception = new ArgumentNullException($"{typeof(T).FullName} must not have more than one copy on the stage!");
                    Debug.LogException(exception);
                }
                _instance = instances[0];
                DontDestroyOnLoad(_instance);
                return _instance;
            }
        }

        /// <summary>
        /// Использовать для создания объекта синглотона до первого обращения к Instance
        /// </summary>
        public static T Register() => Instance;
    }