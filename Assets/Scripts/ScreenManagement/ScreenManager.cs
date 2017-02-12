using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildUI.ScreenManagement
{
    public static class ScreenManager
    {        
        static ScreenManager()
        {

        }
        [RuntimeInitializeOnLoadMethod]
        public static void ShowScreen()
        {
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<Screen>().Init();
        }
    }
}
