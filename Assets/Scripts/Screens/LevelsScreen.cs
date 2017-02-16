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

            ButtonController button = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag0);

            button.Text = "назад";
            button.OnClick += () => HideShow<MainMenuScreen>();

            Text text = CreateItem(UIComponentManager.Components.text, UIContainerTag.Tag3);
            text.text = "сезончик";

            ListViewController listView = CreateItem(UIComponentManager.Components.listView, UIContainerTag.Tag1);
            listView.SetItems(UIComponentManager.Components.button, 10, (item, index) => { item.Text = index.ToString(); item.OnClick += () => Debug.Log(item.Text); });
        }
    }
}
