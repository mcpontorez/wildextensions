using System.Collections.Generic;
using UnityEngine;
using Wild.UI.ScreenManagement;
using Wild.UI.ScreenManagement.Data;
using Wild.UI.Components;
using Wild.UI.Components.Data;
using Wild.UI.Components.Management;
using Wild.UI.MessageBoxes;

namespace Wild.UI.Screens
{
    public class MainMenuScreen : ResourceScreenBase
    {
        protected override string DataPath { get { return "WildUI/Screens/MainMenuScreen"; } }

        protected override void OnInit()
        {
            base.OnInit();

            ToggleController toggle = CreateItem(UIComponentManager.Components.toggle, UIContainerTag.Tag1);
            toggle.ValueChanged += (isOn) => Debug.Log(isOn);

            ButtonController button = CreateItem(UIComponentsData2.Instance.button, UIContainerTag.Tag0);
            button.Text = "играть";
            button.Click += () => HideShow<LevelsScreen>();

            for (int i = 0; i < 3; i++)
            {
                button = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag0);

                button.Text = "кнопка" + i;
                int c = i;
                button.Click += () =>
                {
                    Hide();
                    IMessageBox messagebox = new SimpleMessageBox("Вы уверены?" + c, ScreenManager.Container.ScreensContainer);
                    messagebox.AddButton("показать уровни", () => ScreenManager.ShowScreen<LevelsScreen>(), true);
                    messagebox.AddButton("вернуться", () => ScreenManager.ShowScreen<MainMenuScreen>());
                };
            }
        }
    }
}
