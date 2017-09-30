using UnityEngine;
using UnityEngine.EventSystems;
using Wild.InterfacesMB;
using Wild.UI.ScreenManagement;
using Wild.UI.Screens;

namespace Wild.UI.Demo
{
    public class FirstScreenCaller : MonoBehaviour, IStart
    {
        public void Start()
        {
            IScreenManager screenManager = new ScreenManager();
            screenManager.EventSystem = screenManager.SystemManager.LoadAndAddSystem<EventSystem>("WildUI/ScreenManagement/EventSystem");
            screenManager.ShowScreen<MainMenuScreen>();
        }
    }
}
