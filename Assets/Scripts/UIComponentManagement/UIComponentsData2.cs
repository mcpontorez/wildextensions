using InterfacesMB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wild.Singletons;
using WildUI.UIHelpers;
using System;

namespace WildUI.UIComponents.Data
{
    [CreateAssetMenu(fileName = "UIComponentsData2", menuName = "WildUI/UIComponentsData2")]
    public class UIComponentsData2 : SingletonSO<UIComponentsData2>, IOnValidate
    {
        public ButtonController button;

        public void OnValidate()
        {

        }

        protected override string DataPath
        {
            get
            {
                return "UIComponentsData2";
            }
        }
    }
}
