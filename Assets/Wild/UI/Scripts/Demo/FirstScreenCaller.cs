using UnityEngine;
using UnityEngine.EventSystems;
using Wild.InterfacesMB;
using Wild.UI.ScreenManagement;
using Wild.UI.Screens;

namespace Wild.UI.Demo
{
    public class FirstScreenCaller : MonoBehaviour, IStart
    {
        private static IScreenManager _screenManager = new ScreenManager() { EventSystem = Resources.Load<EventSystem>("WildUI/ScreenManagement/EventSystem") };
        public void Start()
        {
            _screenManager.ShowScreen<MainMenuScreen>();
        }
    }
}
