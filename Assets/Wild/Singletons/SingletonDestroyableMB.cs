﻿using System;
using UnityEngine;
{
    public abstract class SingletonDestroyableMB<T> : MonoBehaviour where T : SingletonDestroyableMB<T>
    {
        /// <summary>
        /// Ссылка на объект синглетона
        /// </summary>

        protected virtual void Awake()
        {
            Instance = (T)this;
        }

        protected virtual void OnDestroy()
        {
            Instance = null;
        }
    }