using UnityEngine;
using Wild.InterfacesMB;
using Wild.Singletons;

namespace Wild.UI.ScreenManagement
{
    public class ScreenManagerContainer : MonoBehaviour, IAwake
    {
        public void Awake()
        {
            DontDestroyOnLoad(gameObject);

            GameObject systemsContainer = new GameObject("Systems");
            SystemsContainer = systemsContainer.transform;
            SystemsContainer.SetParent(transform);

            GameObject screensContainer = new GameObject("Screens");
            ScreensContainer = screensContainer.transform;
            ScreensContainer.SetParent(transform);
        }

        public Transform SystemsContainer { get; private set; }

        public Transform ScreensContainer { get; private set; }
    }
}
