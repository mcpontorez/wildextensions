using System.Collections.Generic;
using UnityEngine;
using Wild.UI.ScreenManagement;
using Wild.UI.ScreenManagement.Data;
using Wild.UI.Components;
using Wild.UI.Components.Data;
using Wild.UI.Components.Management;

namespace Wild.UI.Screens
{
    public class MainMenuScreen : ScreenBase
    {
        protected override string DataPath { get { return "WildUI/Screens/MainMenuScreen"; } }

        protected override void OnInit()
        {
            base.OnInit();

            ButtonController button = CreateItem(UIComponentsData2.Instance.button, UIContainerTag.Tag1);

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
