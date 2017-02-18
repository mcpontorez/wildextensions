using UnityEngine;
using Wild.InterfacesMB;
using Wild.UI.ScreenManagement;
using Wild.UI.Screens;

namespace Wild.UI.Demo
{
    public class FirstScreenCaller : MonoBehaviour, IStart
    {
        public void Start()
        {
            ScreenManager.ShowScreen<MainMenuScreen>();
        }
    }
}
