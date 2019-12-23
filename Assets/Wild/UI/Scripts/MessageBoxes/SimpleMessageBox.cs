using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Wild.UI.Components;
using Wild.UI.Components.Management;
using Wild.UI.ScreenManagement.Data;

namespace Wild.UI.MessageBoxes
{
    public class SimpleMessageBox : MessageBoxBase
    {
        protected override string DataPath { get { return "WildUI/MessageBoxes/SimpleMessageBox"; } }

        private TextController _titleController;

        public SimpleMessageBox(string title = null, Transform container = null) : base(title, container)
        {
        }

        private TextController TitleController
        {
            get
            {
                if (!_titleController)
                   _titleController = CreateItem(UIComponentManager.Components.text, UIContainerTag.Tag1);

                return _titleController;
            }
        }

        public override string Title
        {
            get { return TitleController.Text; }
            set
            {
                TitleController.Text = value;
            }
        }

        public override void AddButton(string text, Action onClick, bool isSecelected = false)
        {
            ButtonController button = CreateItem(UIComponentManager.Components.button, UIContainerTag.Tag0);
            button.Text = text;
            if (isSecelected)
                EventSystem.current.SetSelectedGameObject(button.gameObject);
            button.Click += () => OnButtonClick(onClick);
        }
    }
}
