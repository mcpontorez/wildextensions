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
        protected override string DataPath { get { return "Screens/MainMenuScreen"; } }

        protected override void OnInit()
        {
            base.OnInit();

            ButtonController button = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag1);

            button.Text = "играть";
            button.OnClick += () => HideShow<LevelsScreen>();

            for (int i = 0; i < 3; i++)
            {
                button = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag0);

                button.Text = "кнопка" + i;
                int c = i;
                button.OnClick += () => Debug.Log("кнопка" + c);
            }
        }
    }
}
