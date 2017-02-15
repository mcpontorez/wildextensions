using System.Collections.Generic;
using UnityEngine;
using WildUI.ScreenManagement.Data;

namespace WildUI.ScreenManagement
{
    public abstract class ScreenBase : IScreen
    {
        protected abstract string DataPath { get; }

        protected ScreenData Data { get; private set; }

        void IScreen.Init()
        {
            Data = Resources.Load<ScreenData>(DataPath);
            Data = Object.Instantiate(Data);

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
            OnDestroy();
            Object.Destroy(Data.gameObject);
        }

        protected virtual void OnDestroy() { }
    }
}
