using System.Collections.Generic;
using UnityEngine;
using Wild.UI.ScreenManagement.Data;

namespace Wild.UI.MessageBoxes
{
    public abstract class MessageBoxBase : IMessageBox
    {
        protected abstract string DataPath { get; }

        public ScreenData Data { get; private set; }

        public abstract string Title { get; set; }

        protected MessageBoxBase(string title = null, Transform container = null)
        {
            Data = Resources.Load<ScreenData>(DataPath);
            Data = Object.Instantiate(Data);
            Object.DontDestroyOnLoad(Data.gameObject);

            if (container)
                Data.transform.parent = container;
            if (!string.IsNullOrEmpty(title))
                Title = title;
        }

        public abstract void AddButton(string text, System.Action onClick, bool isSecelected = false);

        protected void OnButtonClick(System.Action onClick)
        {
            HideAndDestroy();
            onClick();
        }

        protected virtual void HideAndDestroy()
        {
            OnHideAndDestroy();
            Object.Destroy(Data.gameObject);
        }

        public virtual void OnHideAndDestroy()
        {

        }

        #region InstantiateItem
        /// <summary>
        /// Создаёт го в UIContainer
        /// </summary>
        /// <returns>созданный объект</returns>
        protected T CreateItem<T>(T sample, UIContainer container) where T : Component
        {
            return Object.Instantiate(sample, container.RectTransform, false);
        }
        /// <summary>
        /// Создаёт GO в UIContainer
        /// </summary>
        /// <returns>созданный объект</returns>
        protected T CreateItem<T>(T sample, UIContainerTag containerTag) where T : Component
        {
            return CreateItem(sample, Data.GetUIContainer(containerTag));
        }
        #endregion
    }
}
