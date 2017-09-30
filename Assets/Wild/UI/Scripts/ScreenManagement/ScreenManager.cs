using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Wild.Generics;
using Wild.Systems.Management;

namespace Wild.UI.ScreenManagement
{
    public class ScreenManager : IScreenManager
    {
        public ScreenManager()
        {
            GameObject sm = new GameObject("ScreenManager");
            Container = sm.AddComponent<ScreenManagerContainer>();

            SystemManager = new SystemManager(Container.SystemsContainer);
            //EventSystem = SystemManager.LoadAndAddSystem<EventSystem>("WildUI/ScreenManagement/EventSystem");
        }

        public ScreenManagerContainer Container { get; private set; }

        public EventSystem EventSystem { get; set; }

        public SystemManager SystemManager { get; private set; }

        private Dictionary<System.Type, IScreen> _screens = new Dictionary<System.Type, IScreen>();

        public TScreen ShowScreen<TScreen>(int? sortOrder = null) where TScreen : IScreen, new()
        {
            System.Type screenType = typeof(TScreen);

            TScreen screen;

            if (!_screens.ContainsKey(screenType))
            {
                screen = new TScreen() { ScreenManager = this };
                _screens.Add(screenType, screen);
                screen.Data.transform.SetParent(Container.ScreensContainer);
                screen.Init();
            }
            else
                screen = (TScreen)_screens[screenType];

            if (sortOrder != null)
                screen.Data.CanvasController.CanvasComponent.sortingOrder = (int)sortOrder;

            screen.Show();

            return screen;
        }

        public TScreen ShowScreen<TScreen>(IGenericNewTypeContainer<TScreen> screenTypeContainer, int? sortOrder = null) where TScreen : IScreen
        {
            System.Type screenType = screenTypeContainer.GetGenericType();

            TScreen screen;

            if (!_screens.ContainsKey(screenType))
            {
                screen = (TScreen)System.Activator.CreateInstance(screenType);
                screen.ScreenManager = this;
                _screens.Add(screenType, screen);
                screen.Data.transform.SetParent(Container.ScreensContainer);
                screen.Init();
            }
            else
                screen = (TScreen)_screens[screenType];

            if (sortOrder != null)
                screen.Data.CanvasController.CanvasComponent.sortingOrder = (int)sortOrder;

            screen.Show();

            return screen;
        }

        public void HideScreen<T>() where T: IScreen
        {
            System.Type screenType = typeof(T);

            if (_screens.ContainsKey(screenType))
                _screens[screenType].Hide();
        }

        public void DestroyScreen<T>() where T : IScreen
        {
            System.Type screenType = typeof(T);

            if (!_screens.ContainsKey(screenType))
                return;

            _screens[screenType].Destroy();
            _screens.Remove(screenType);
        }
    }
}
