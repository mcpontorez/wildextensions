using System.Collections.Generic;
using UnityEngine;
using WildUI.ScreenManagement;
using WildUI.ScreenManagement.Data;
using WildUI.UIComponents;
using WildUI.UIComponents.Management;

namespace WIldUI.Screens
{
    class MainMenuScreen : ScreenBase
    {
        protected override string DataPath { get { return "MainMenuScreen"; } }

        protected override void OnInit()
        {
            base.OnInit();

            ButtonController button = Object.Instantiate(UIComponentManager.Components.button, Data.GetUIContainerRectTransform(UIContainerTag.Tag1), false);

            button.Text = "играть";
            button.OnClick += () => Debug.Log("играю");

            for (int i = 0; i < 3; i++)
            {
                button = Object.Instantiate(UIComponentManager.Components.button, Data.GetUIContainerRectTransform(UIContainerTag.Tag0), false);

                button.Text = "кнопка" + i;
                int c = i;
                button.OnClick += () => Debug.Log("кнопка" + c);
            }
        }
    }
}
