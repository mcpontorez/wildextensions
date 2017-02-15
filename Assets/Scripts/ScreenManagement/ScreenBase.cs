using System.Collections.Generic;
using UnityEngine;
using WildUI.ScreenManagement.Data;

namespace WildUI.ScreenManagement
{
    public abstract class ScreenBase : IScreen
    {
        protected abstract string DataPath { get; }

        protected ScreenData _data;

        void IScreen.Init()
        {
            _data = Resources.Load<ScreenData>(DataPath);
            _data = Object.Instantiate(_data);

            OnInit();
        }

        protected virtual void OnInit() { }

        void IScreen.Show()
        {
            _data.gameObject.SetActive(true);
            OnShow();
        }

        protected virtual void OnShow() { }

        void IScreen.Hide()
        {
            _data.gameObject.SetActive(false);
            OnHide();
        }

        protected virtual void OnHide() { }

        void IScreen.Destroy()
        {
            OnDestroy();
            Object.Destroy(_data.gameObject);
        }

        protected virtual void OnDestroy() { }
    }
}
