using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

            Text text = Object.Instantiate(UIComponentManager.Components.text, Data.GetUIContainerRectTransform(UIContainerTag.Tag3), false);
            text.text = "сезончик";

            ListViewController listView = Object.Instantiate(UIComponentManager.Components.listView, Data.GetUIContainerRectTransform(UIContainerTag.Tag1), false);
            listView.SetItems(UIComponentManager.Components.button, 10, (item, index) => { item.Text = index.ToString(); item.OnClick += () => Debug.Log(item.Text); });
        }
    }
}
