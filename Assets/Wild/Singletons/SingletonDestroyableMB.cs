using System;
using UnityEngine;namespace Wild.Singletons
{
    public abstract class SingletonDestroyableMB<T> : MonoBehaviour where T : SingletonDestroyableMB<T>
    {
        /// <summary>
        /// Ссылка на объект синглетона
        /// </summary>        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            Instance = (T)this;
        }

        protected virtual void OnDestroy()
        {
            Instance = null;
        }
    }}