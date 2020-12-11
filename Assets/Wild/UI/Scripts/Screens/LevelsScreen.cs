using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wild.UI.ScreenManagement;
using Wild.UI.ScreenManagement.Data;
using Wild.UI.Components;
using Wild.UI.Components.Management;

namespace Wild.UI.Screens
{
    public class LevelsScreen : ResourceScreenBase
    {
        protected override string DataPath { get { return "WildUI/Screens/LevelsScreen"; } }

        private CollectionViewController _levelList;

        protected override void OnInit()
        {
            base.OnInit();

            ButtonController button = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag0);
            button.Text = "назад";
            button.Click += () => HideShow<MainMenuScreen>();

            TextController title = CreateItem(UIComponentManager.Components.text, UIContainerTag.Tag3);
            title.Text = "сезончик";
            title.TextComponent.fontSize = 30;

            ButtonController leftButton = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag4);
            leftButton.Text = "лево";
            leftButton.Click += UpdateLevelList;

            ButtonController rightButton = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag5);
            rightButton.Text = "право";
            rightButton.Click += UpdateLevelList;

            _levelList = CreateItem(UIComponentManager.Components.collectionView, UIContainerTag.Tag1);
            UpdateLevelList();
            _levelList.CollectionGrouper.SetAsList(60f, 10f);
        }

        private void UpdateLevelList()
        {
            _levelList.SetItems(UIComponentManager.Components.toggle, Random.Range(9, 100), (sender, args) =>
            {
                args.Item.Text = args.Index.ToString(); args.Item.ValueChanged += (a) => Debug.Log(args.Item.Text + a);
            });
        }
    }
}
