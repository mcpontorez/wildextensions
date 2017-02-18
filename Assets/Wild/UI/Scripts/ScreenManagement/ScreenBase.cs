﻿using UnityEngine;
using Wild.UI.ScreenManagement.Data;

namespace Wild.UI.ScreenManagement
{
    public abstract class ScreenBase : IScreen
    {
        protected abstract string DataPath { get; }

        public ScreenData Data { get; private set; }

        void IScreen.Init()
        {
            Data = Resources.Load<ScreenData>(DataPath);
            Data = Object.Instantiate(Data);
            Data.gameObject.SetActive(false);
            Object.DontDestroyOnLoad(Data.gameObject);

            OnInit();
        }

        protected virtual void OnInit() { }

        void IScreen.Show()
        {
            Data.gameObject.SetActive(true);
            OnShow();
        }

        protected virtual void OnShow() { }

        public void Hide()
        {
            Data.gameObject.SetActive(false);
            OnHide();
        }

        protected virtual void OnHide() { }

        protected void HideShow<T>() where T : IScreen, new()
        {
            Hide();
            ScreenManager.ShowScreen<T>();
        }

        void IScreen.Destroy()
        {
            Hide();
            OnDestroy();
            Object.Destroy(Data.gameObject);
        }

        protected virtual void OnDestroy() { }

        #region InstantiateItem
        /// <summary>
        /// Создаёт го в UIContainer
        /// </summary>
        /// <returns>созданный объект</returns>
        protected T CreateItem<T>(T sample, UIContainer container) where T : Component
        {
            return Object.Instantiate(sample, container.rectTransform, false);
        }
        /// <summary>
        /// Создаёт го в UIContainer
        /// </summary>
        /// <returns>созданный объект</returns>
        protected T CreateItem<T>(T sample, UIContainerTag containerTag) where T : Component
        {
            return CreateItem(sample, Data.GetUIContainer(containerTag));
        }
        #endregion
    }
}