using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wild.UI.ScreenManagement;
using Wild.UI.ScreenManagement.Data;
using Wild.UI.Components;
using Wild.UI.Components.Management;

namespace Wild.UI.Screens
{
    class LevelsScreen : ScreenBase
    {
        protected override string DataPath { get { return "WildUI/Screens/LevelsScreen"; } }

        private ButtonController _leftButton;
        private ButtonController _rightButton;
        private ListViewController _levelList;

        protected override void OnInit()
        {
            base.OnInit();

            ButtonController button = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag0);
            button.Text = "назад";
            button.OnClick += () => HideShow<MainMenuScreen>();

            Text text = CreateItem(UIComponentManager.Components.text, UIContainerTag.Tag3);
            text.text = "сезончик";

            _leftButton = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag4);
            _leftButton.Text = "лево";
            _leftButton.OnClick += UpdateLevelList;

            _rightButton = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag5);
            _rightButton.Text = "право";
            _rightButton.OnClick += UpdateLevelList;

            _levelList = CreateItem(UIComponentManager.Components.listView, UIContainerTag.Tag1);
            UpdateLevelList();
        }

        private void UpdateLevelList()
        {
            _levelList.SetItems(UIComponentManager.Components.button, Random.Range(9, 100), (item, index) =>
            {
                item.Text = index.ToString(); item.OnClick += () => Debug.Log(item.Text);
            });
        }
    }
}
