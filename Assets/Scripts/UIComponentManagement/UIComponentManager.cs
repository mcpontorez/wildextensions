using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildUI.UIComponents.Data;

namespace WildUI.UIComponents.Management
{
    public static class UIComponentManager
    {
        private static UIComponentsData _components;

        public static UIComponentsData Components
        {
            get
            {
                if(!_components)
                {
                    _components = Resources.Load<UIComponentsData>("UIComponentManagement/UIComponentsData");
                }
                return _components;
            }
        }
    }
}