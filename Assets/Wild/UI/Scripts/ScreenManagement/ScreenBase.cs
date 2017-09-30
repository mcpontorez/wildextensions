using UnityEngine;
using Wild.Generics;
using Wild.UI.ScreenManagement.Data;

namespace Wild.UI.ScreenManagement
{
    public abstract class ScreenBase : IScreen
    {
        protected abstract string DataPath { get; }

        public ScreenData Data { get; private set; }

        public IScreenManager ScreenManager { get; set; }

        protected ScreenBase()
        {
            Data = Resources.Load<ScreenData>(DataPath);
            Data = Object.Instantiate(Data);
            Object.DontDestroyOnLoad(Data.gameObject);
            Data.gameObject.SetActive(false);
        }

        void IScreen.Init()
        {
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

        protected virtual void OnHide()
        {
            ResetCurrentSelectedGameObject();
        }

        protected T HideShow<T>() where T : IScreen, new()
        {
            Hide();
            return ScreenManager.ShowScreen<T>();
        }

        protected IScreen HideShow<T>(IGenericNewTypeContainer<T> screenTypeContainer) where T : IScreen
        {
            Hide();
            return ScreenManager.ShowScreen(screenTypeContainer);
        }

        protected T ShowUp<T>() where T : IScreen, new()
        {
            return ScreenManager.ShowScreen<T>(Data.CanvasController.CanvasComponent.sortingOrder + 1);
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
        /// Создаёт GO в UIContainer
        /// </summary>
        /// <returns>созданный объект</returns>
        protected T CreateItem<T>(T sample, UIContainerTag containerTag) where T : Component
        {
            return CreateItem(sample, Data.GetUIContainer(containerTag));
        }
        #endregion

        protected virtual GameObject ShowedSelectedGameObject { get; set; }

        protected void SetShowedSelectedGameObject<TComponent>(TComponent component) where TComponent : Component
        {
            ShowedSelectedGameObject = component.gameObject;
        }

        protected GameObject CurrentSelectedGameObject
        {
            get { return ScreenManager.EventSystem.currentSelectedGameObject; }
            set { ScreenManager.EventSystem.SetSelectedGameObject(value); }
        }

        protected void SetSelectedGameObject<TComponent>(TComponent component) where TComponent : Component
        {
            CurrentSelectedGameObject = component.gameObject;
        }

        protected void ResetCurrentSelectedGameObject()
        {
            CurrentSelectedGameObject = null;
        }
    }
}
