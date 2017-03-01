using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Wild.UI.ScreenManagement
{
    public static class ScreenManager
    {        
        static ScreenManager()
        {
            GameObject sm = new GameObject("ScreenManager");
            Container = sm.AddComponent<ScreenManagerContainer>();

            SystemManager = new ScreenSystemManager(Container.SystemsContainer);
            EventSystem = SystemManager.LoadAndAddSystem<EventSystem>("WildUI/ScreenManagement/EventSystem");
        }

        private static ScreenManagerContainer Container { get; set; }

        public static EventSystem EventSystem { get; private set; }

        public static ScreenSystemManager SystemManager { get; private set; }

        private static Dictionary<System.Type, IScreen> _screens = new Dictionary<System.Type, IScreen>();

        public static void ShowScreen<T>() where T : IScreen, new()
        {
            System.Type screenType = typeof(T);

            if (!_screens.ContainsKey(screenType))
            {
                T screen = new T();
                screen.Init();
                _screens.Add(screenType, screen);
                screen.Data.transform.SetParent(Container.ScreensContainer);
            }

            _screens[screenType].Show();
        }

        public static void HideScreen<T>() where T: IScreen
        {
            System.Type screenType = typeof(T);

            if (_screens.ContainsKey(screenType))
                _screens[screenType].Hide();
        }

        public static void DestroyScreen<T>() where T : IScreen
        {
            System.Type screenType = typeof(T);

            if (!_screens.ContainsKey(screenType))
                return;

            _screens[screenType].Destroy();
            _screens.Remove(screenType);
        }
    }
}
