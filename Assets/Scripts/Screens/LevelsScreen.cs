using System.Collections.Generic;
using UnityEngine;
using WildUI.ScreenManagement;
using WildUI.ScreenManagement.Data;
using WildUI.UIComponents;
using WildUI.UIComponents.Management;

namespace WIldUI.Screens
{
    class LevelsScreen : ScreenBase
    {
        protected override string DataPath { get { return "LevelsScreen"; } }

        protected override void OnInit()
        {
            base.OnInit();

            ButtonController button = Object.Instantiate(UIComponentManager.Components.button, Data.GetUIContainerRectTransform(UIContainerTag.Tag0), false);

            button.Text = "назад";
            button.OnClick += () => HideShow<MainMenuScreen>();
        }
    }
}
