using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wild.UI.Components.Data;

namespace Wild.UI.Components.Management
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
                    _components = Resources.Load<UIComponentsData>("WildUI/UIComponentManagement/UIComponentsData");
                }
                return _components;
            }
        }
    }
}