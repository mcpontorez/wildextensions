using InterfacesMB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WildUI.UIHelpers;

namespace WildUI.UIComponents.Data
{
    [CreateAssetMenu(fileName = "UIComponentsData", menuName = "WildUI/UIComponentsData")]
    public class UIComponentsData : ScriptableObject, IOnValidate
    {
        public CanvasController canvas;
        public ButtonController button;
        public RectTransform panel;
        public ListViewController listView;

        public void OnValidate()
        {

        }
    }
}
