﻿using UnityEngine;
{
    public abstract class SingletonMB<T> : MonoBehaviour where T : SingletonMB<T>
    {
        private static T _instance;
        /// <summary>
        /// Ссылка на объект синглетона
        /// </summary>
        {
            get
            {
                if (_instance)
                    return _instance;

                GameObject singletonGO = new GameObject();
                _instance = singletonGO.AddComponent<T>();
                singletonGO.name = "(singleton) " + typeof(T).ToString();

                DontDestroyOnLoad(singletonGO);
                _instance.Initialize();
                return _instance;
            }
        }
        /// <summary>
        /// Использовать для инициализации объекта синглотона, например загрузки из ScriptableObject нужных данных
        /// </summary>
        /// <summary>
        /// Использовать для создания объекта синглотона до первого обращения к Instance
        /// </summary>
        public static T Register()
        {
            return Instance;
        }
        /// <summary>
        /// Создаёт ГО с переданным скриптом на сцене и удочеряет
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="objectToAdoption"></param>
        /// <returns>ссылка на объект скрипта в созданном ГО</returns>
        {
            objectToAdoption = Instantiate(objectToAdoption);
            objectToAdoption.transform.parent = transform;
            return objectToAdoption;
        }
        /// <summary>
        /// Создаёт на сцене ГО и удочеряет
        /// </summary>
        /// <param name="objectToAdoption"></param>
        /// <returns>ссылка на созданный на сцене ГО</returns>
        {
            objectToAdoption = Instantiate(objectToAdoption);
            objectToAdoption.transform.SetParent(transform);
            return objectToAdoption;
        }
    }