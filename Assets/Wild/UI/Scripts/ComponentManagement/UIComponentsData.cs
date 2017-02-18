﻿using Wild.InterfacesMB;
using UnityEngine;
using UnityEngine.UI;

namespace Wild.UI.Components.Data
{
    [CreateAssetMenu(fileName = "UIComponentsData", menuName = "WildUI/UIComponentsData")]
    public class UIComponentsData : ScriptableObject, IOnValidate
    {
        public CanvasController canvas;
        public ButtonController button;
        public RectTransform panel;
        public ListViewController listView;
        public Text text;

        public void OnValidate()
        {

        }
    }
}