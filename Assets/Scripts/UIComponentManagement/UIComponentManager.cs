using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildUI.UIComponentsManagement.Data;

namespace WildUI.UIComponentsManagement
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
                    _components = Resources.Load<UIComponentsData>(" ");
                }
                return _components;
            }
        }
    }
}