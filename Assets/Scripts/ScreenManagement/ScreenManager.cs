using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WildUI.ScreenManagement
{
    public static class ScreenManager
    {        
        static ScreenManager()
        {
            GetEventSystem();
        }
        [RuntimeInitializeOnLoadMethod]
        private static void ShowScreenExample()
        {
            ShowScreen<WIldUI.Screens.MainMenuScreen>();
        }

        private static EventSystem _eventSystem;
        public static EventSystem GetEventSystem()
        {
            if (!_eventSystem)
            {
                _eventSystem = Resources.Load<EventSystem>("WildUI/ScreenManagement/EventSystem");
                _eventSystem = Object.Instantiate(_eventSystem);
                Object.DontDestroyOnLoad(_eventSystem.gameObject);
            }
            return _eventSystem;
        }

        private static Dictionary<System.Type, IScreen> _screens = new Dictionary<System.Type, IScreen>();

        public static void ShowScreen<T>() where T : IScreen, new()
        {
            System.Type screenType = typeof(T);

            if (!_screens.ContainsKey(screenType))
            {
                T screen = new T();
                screen.Init();
                _screens.Add(screenType, screen);
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
