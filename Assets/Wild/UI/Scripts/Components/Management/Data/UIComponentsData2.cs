using Wild.InterfacesMB;
using UnityEngine;
using Wild.Singletons;

namespace Wild.UI.Components.Data
{
    [CreateAssetMenu(fileName = "UIComponentsData2", menuName = "Wild/UI/Singletons/UIComponentsData2")]
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
                return "WildUI/UIComponentsData2";
            }
        }
    }
}
