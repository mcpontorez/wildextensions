using InterfacesMB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WildUI.UIComponents.Data
{
    [CreateAssetMenu(fileName = "UIComponentsData", menuName = "WildUI/UIComponentsData")]
    public class UIComponentsData : ScriptableObject, IOnValidate
    {
        public Canvas canvas;
        public ButtonController button;

        public void OnValidate()
        {

        }
    }
}
